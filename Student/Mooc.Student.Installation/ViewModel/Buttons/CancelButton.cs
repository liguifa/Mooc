using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentClient.Installation
{
    public class CancelButton
    {
        public string Text { get; set; }

        public ICommand Command { get; set; }

        public CancelButton()
        {
            this.Text = "取消";
            this.Command = new CancelCommand();
        }
    }

    public class CancelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
