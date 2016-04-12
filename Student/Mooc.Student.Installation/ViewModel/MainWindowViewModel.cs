using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.UI.Common;

namespace StudentClient.Installation
{
    public class MainWindowViewModel : BaseINotifyPropertyChanged
    {
        private static MainWindowViewModel mainWindow;
        private static readonly object syncRoot = new object();
        private int mPageId = 0;

        private MainWindowViewModel()
        {
            this.mCurrentPage = new Uri(this.Catalog.First(), UriKind.Relative);
        }

        public static MainWindowViewModel GetInstance()
        {
            if (mainWindow == null)
            {
                lock (syncRoot)
                {
                    if (mainWindow == null)
                    {
                        mainWindow = new MainWindowViewModel();
                    }
                }
            }
            return mainWindow;
        }

        public List<string> Catalog = new List<string>()
        {
            "/Views/ServiceConfiguration.xaml",
            "/Views/ConfigurationProcess.xaml",
            "/Views/ConfigurationFinish.xaml",
        };

        private Uri mCurrentPage;
        public Uri CurrentPage { get { return this.mCurrentPage; } set { this.mCurrentPage = value; OnPropertyChanged("CurrentPage"); } }

        public void NextPage()
        {
            this.CurrentPage = new Uri(this.Catalog[++this.mPageId], UriKind.Relative);
        }
    }
}
