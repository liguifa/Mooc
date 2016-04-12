using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Mooc.Tearcher.Client
{
    public class LoginButton : Button
    {
        public LoginButton()
        {
            this.Text = "登  录";
            this.IsEnabled = false;
            this.ButtonVisiblity = Visibility.Visible;
            this.Command = new LoginCommand();
        }
    }

    public class LoginCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
           
        }
    }
}
