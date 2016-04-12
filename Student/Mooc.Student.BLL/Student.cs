using Common.Logger;
using StudentClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Function;

namespace StudentClient.BLL
{
    public class Student : BaseBLL<StudentClient.Models.Student>
    {
        private static readonly Logger mLog = Logger.GetInstance(MethodBase.GetCurrentMethod().DeclaringType);

        public LoginInModel<StudentClient.Models.Student> Login(string username, string password)
        {
            try
            {
                LoginInModel<StudentClient.Models.Student> loginIn = new LoginInModel<StudentClient.Models.Student>();
                if (base.SearchCount(d => !d.Student_IsDel && d.Student_Email.Equals(username)) > 0)
                {
                    List<StudentClient.Models.Student> students = base.Search(d => !d.Student_IsDel && d.Student_Email.Equals(username));
                    if (students.Count > 0)
                    {
                        StudentClient.Models.Student student = students.First();
                        if (student.Student_Password.Equals(Md5.GetEncryptionValue(password)))
                        {
                            loginIn.IsLogin = true;
                            loginIn.CurrentUser = student;
                            return loginIn;
                        }
                    }
                }
                loginIn.IsLogin = false;
                return loginIn;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the login,error:{0}", e.ToString());
                throw;
            }
        }

        public AdminStudentListModel GetStudentByIndex(string pageIndex, string pageSize)
        {
            try
            {
                AdminStudentListModel list = new AdminStudentListModel();
                list.total = base.SearchCount(d => !d.Student_IsDel);
                list.rows = base.Search(d => !d.Student_IsDel, d => d.Student_StuId, int.Parse(pageIndex), int.Parse(pageSize));
                list.footer = new AdminStudentListModel.Footer() { number = 20 };
                return list;
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the get student by index,error:{0}", e.ToString());
                throw;
            }
        }

        public AdminStudentUpdate UpdateStudentInfo(string studentId, string studentName)
        {
            AdminStudentUpdate adminStudentUpdate = new AdminStudentUpdate();
            try
            {
                List<StudentClient.Models.Student> students = base.Search(d => d.Student_Id == Guid.Parse(studentId) && !d.Student_IsDel);
                if (students.Count > 0)
                {
                    StudentClient.Models.Student student = students.First();
                    student.Student_Name = studentName;
                    base.Modify(student, "Student_Name");
                    adminStudentUpdate.IsUpdate = true;
                    adminStudentUpdate.StudentId = student.Student_Id;
                }
            }
            catch (Exception e)
            {
                mLog.Error("An error has occurred in the update student info,error:{0}", e.ToString());
                adminStudentUpdate.IsUpdate = false;
                adminStudentUpdate.Error = e.Message;
            }
            return adminStudentUpdate;
        }
    }
}
