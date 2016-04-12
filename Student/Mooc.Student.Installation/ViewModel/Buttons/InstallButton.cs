using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentClient.Installation
{
    public class InstallButton
    {
        public string Text { get; set; }

        public ICommand Command { get; set; }

        public InstallButton()
        {
            this.Text = "安装";
            this.Command = new InstallCommand();
        }
    }

    public class InstallCommand : ICommand
    {
        public delegate bool IsCanInstallDelegate();

        public event IsCanInstallDelegate IsCanInstall;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.IsCanInstall();
        }

        public void Execute(object parameter)
        {
            InstallProccess install = new InstallProccess("127.0.0.1", "1234", "", "", "");
            install.Start();
            MainWindowViewModel.GetInstance().NextPage();
        }
    }
}
