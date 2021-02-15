using MyJourney.Model;
using MyJourney.ViewModel.Commands;
using System.ComponentModel;

namespace MyJourney.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                Users = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                Users = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                Users = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private Users users;

        public Users Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterVM()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Register(Users users)
        {
            Users.Register(Users);
        }
    }
}
