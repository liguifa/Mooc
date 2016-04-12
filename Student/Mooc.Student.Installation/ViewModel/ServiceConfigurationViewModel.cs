using MMS.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.Installation
{
    public class ServiceConfigurationViewModel : BaseINotifyPropertyChanged
    {
        private static ServiceConfigurationViewModel serviceConfiguration;
        private static readonly object syncRoot = new object();

        private ServiceConfigurationViewModel()
        {
        }

        public static ServiceConfigurationViewModel GetInstance()
        {
            if (serviceConfiguration == null)
            {
                lock (syncRoot)
                {
                    if (serviceConfiguration == null)
                    {
                        serviceConfiguration = new ServiceConfigurationViewModel();
                    }
                }
            }
            return serviceConfiguration;
        }

        private InstallButton mInstallButton = new InstallButton();
        public InstallButton InstallButton { get { return this.mInstallButton; } set { this.mInstallButton = value; OnPropertyChanged("InstallButton"); } }

        private CancelButton mCancelButton = new CancelButton();
        public CancelButton CancelButton { get { return this.mCancelButton; } set { this.mCancelButton = value; OnPropertyChanged("CancelButton"); } }
    }
}
