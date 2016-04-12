using MMS.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentClient.Installation
{
    public class ConfigurationProcessViewModel : BaseINotifyPropertyChanged
    {
        private static ConfigurationProcessViewModel proccess;
        private static readonly object syncRoot = new object();

        private ConfigurationProcessViewModel()
        {

        }

        public static ConfigurationProcessViewModel GetInstance()
        {
            if (proccess == null)
            {
                lock (syncRoot)
                {
                    if (proccess == null)
                    {
                        proccess = new ConfigurationProcessViewModel();
                    }
                }
            }
            return proccess;
        }

        private string mProccessText = "";
        public string ProccessText { get { return this.mProccessText; } set { this.mProccessText = value; OnPropertyChanged("ProccessText"); } }

        private string mProccessPercent = "";
        public string ProccessPercent { get { return this.mProccessPercent; } set { this.mProccessPercent = value; OnPropertyChanged("ProccessPercent"); } }

        private int mProccessLength = 0;
        public int ProccessLength { get { return this.mProccessLength; } set { this.mProccessLength = value; OnPropertyChanged("ProccessLength"); } }

        public void UpdateProccess(string text, int percent)
        {
            this.ProccessText = text;
            this.ProccessPercent = String.Format("{0}%", percent);
            this.ProccessLength = (int)Math.Ceiling(((double)percent / 100) * 580);
            if (percent == 100)
            {
                Thread.Sleep(1000);
                MainWindowViewModel.GetInstance().NextPage();
            }
        }
    }
}
