using MyJourney.Model;
using System;
using System.Windows.Input;

namespace MyJourney.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public MainVM ViewModel { get; set; }

        public LoginCommand(MainVM viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var users = (Users)parameter;

            if (users == null)
                return false;

            if (string.IsNullOrEmpty(users.Email) || string.IsNullOrEmpty(users.Password))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Login();
        }
    }
}
