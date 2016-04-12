using Common.Logger;
using MMS.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mooc.Tearcher.Client
{
    public class MainWindowViewModel : BaseINotifyPropertyChanged
    {
        private static MainWindowViewModel mMainWindow;
        private static readonly Logger mLog = Logger.GetInstance(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly object mSyncRoot = new object();

        private MainWindowViewModel()
        {
            this.LoginButton = new LoginButton();
        }

        public static MainWindowViewModel GetInstance()
        {
            if (mMainWindow == null)
            {
                lock (mSyncRoot)
                {
                    if (mMainWindow == null)
                    {
                        mMainWindow = new MainWindowViewModel();
                    }
                }
            }
            return mMainWindow;
        }

        public LoginButton LoginButton { get; set; }

        private string mAccount = String.Empty;
        public string Account { get { return this.mAccount; } set { this.mAccount = value; OnPropertyChanged("Account"); this.ConvertLoginButtonEnable(); } }

        private string mPassword = String.Empty;
        public string Password { get { return this.mPassword; } set { this.mPassword = value; OnPropertyChanged("Password"); this.ConvertLoginButtonEnable(); } }

        public void ConvertLoginButtonEnable()
        {
            this.LoginButton.IsEnabled = !String.IsNullOrEmpty(this.Account) && !String.IsNullOrEmpty(this.Password);
        }
    }
}
