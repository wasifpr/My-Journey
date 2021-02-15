using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyJourney.Model
{
    public class Users : INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
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
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                password = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public static async Task<bool> Login(String email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                try
                {
                    var users = (await App.MobileService.GetTable<Users>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                    if (users != null)
                    {
                        App.users = users;
                        if (users.Password == password)

                            return true;
                        else
                            return false;

                    }
                    else
                    {
                        return false;

                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //internal Task<bool> Login(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public static async void Register(Users users)
        {
            await App.MobileService.GetTable<Users>().InsertAsync(users);
        }
    }
}
