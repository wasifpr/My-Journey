using MyJourney.Model;
using System;
using System.Windows.Input;

namespace MyJourney.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterVM viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterCommand(RegisterVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            Users users = (Users)parameter;

            if (users != null)
            {
                if (users.Password == users.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(users.Email) || string.IsNullOrEmpty(users.Password))
                        return false;

                    return true;
                }

                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Users Users = (Users)parameter;
            viewModel.Register(Users);
        }
    }
}
