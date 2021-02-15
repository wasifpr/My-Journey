using MyJourney.Model;
using MyJourney.ViewModel.Commands;
using System.ComponentModel;

namespace MyJourney.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private Users users;

        public Users Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterNavigationCommand RegisterNavigationCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

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
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                Users = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM()
        {
            Users = new Users();
            LoginCommand = new LoginCommand(this);
            RegisterNavigationCommand = new RegisterNavigationCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await Users.Login(Users.Email, Users.Password);

            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
