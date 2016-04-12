using StudentClient.Installation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentClient.Installation.Views
{
    /// <summary>
    /// ServiceConfiguration.xaml 的交互逻辑
    /// </summary>
    public partial class ServiceConfiguration : Page
    {
        public ServiceConfiguration()
        {
            InitializeComponent();
            this.DataContext = ServiceConfigurationViewModel.GetInstance();
            ((InstallCommand)(ServiceConfigurationViewModel.GetInstance().InstallButton.Command)).IsCanInstall += ServiceConfiguration_IsCanInstall;
        }

        private bool ServiceConfiguration_IsCanInstall()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach(IPAddress ip in ips)
            {
                if (ip.ToString().Equals(this.address.Text))
                {

                }
            }
        }
    }
}
