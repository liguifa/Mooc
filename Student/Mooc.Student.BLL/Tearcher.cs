using Common.Function;
using Common.Logger;
using StudentClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.BLL
{
    public class Tearcher : BaseBLL<StudentClient.Models.Teacher>
    {
        private static readonly Logger mLog = Logger.GetInstance(MethodBase.GetCurrentMethod().DeclaringType);

        public LoginInModel<StudentClient.Models.Teacher> Login(string username, string password)
        {
            try
            {
                LoginInModel<StudentClient.Models.Teacher> loginIn = new LoginInModel<StudentClient.Models.Teacher>();
                mLog.Info("Start Login treaher client,username:[{0}],password:[{1}].", username, Md5.GetEncryptionValue(password));
                if (base.Search(d => d.Teacher_TeaId == username && !d.Teacher_IsDel).Count > 0)
                {
                    List<StudentClient.Models.Teacher> tearchers = base.Search(d => d.Teacher_TeaId == username && !d.Teacher_IsDel).ToList();
                    if (tearchers.Count > 1)
                    {
                        mLog.Warn("There are more than one account user,username:[{0}].", username);
                    }
                    StudentClient.Models.Teacher tearcher = tearchers.First();
                    mLog.Info("Find users,username:[{0}],password:[{1}],realname:[{2}].", tearcher.Teacher_TeaId, tearcher.Teacher_Password, tearcher.Teacher_Name);
                    if (Md5.GetEncryptionValue(password).Equals(tearcher.Teacher_Password))
                    {
                        mLog.Info("Login success.");
                        loginIn.IsLogin = true;
                        loginIn.CurrentUser = tearcher;
                    }
                    else
                    {
                        mLog.Info("Login failed, password error.");
                        loginIn.IsLogin = false;
                    }
                }
                else
                {
                    mLog.Info("Login failed, username error.");
                    loginIn.IsLogin = false;
                }
                return loginIn;
            }
            catch (Exception e)
            {
                mLog.Error("An error occurre when login tearcher client,error:{0}", e.ToString());
                throw;
            }
        }
    }
}
