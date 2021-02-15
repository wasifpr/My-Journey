using MyJourney.Model;
using MyJourney.ViewModel;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyJourney
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainVM viewModel;
        public MainPage()
        {
            InitializeComponent();



            var assembly = typeof(MainPage);

            iconimage.Source = ImageSource.FromResource("MyJourney.Assets.Images.plane.png", assembly);

            viewModel = new MainVM();
            BindingContext = viewModel;
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {

            //bool isEmailEmpty = string.IsNullOrEmpty(emailentry.Text);
            //bool isPasswordEmpty = string.IsNullOrEmpty(passwordentry.Text);

            //if (isEmailEmpty || isPasswordEmpty)
            //{ }
            //else
            //{
            //    var users = (await App.MobileService.GetTable<Users>().Where(u=>u.Email == emailentry.Text).ToListAsync()).FirstOrDefault();
            //    if (users != null)
            //    {
            //        App.users = users;
            //        if (users.Password == passwordentry.Text)



            //            await Navigation.PushAsync(new HomePage());

            //        else
            //            await DisplayAlert("Error", "email or password is not correct", "okay");
            //    }
            //    else
            //    {
            //        await DisplayAlert("Error", "Promblem while Logging...!!! May be You are not registered", "okay");


            //    }
            //}

            bool canLogin = await Users.Login(emailentry.Text, passwordentry.Text);
            if (canLogin)
                await Navigation.PushAsync(new HomePage());
            else
                await DisplayAlert("error ", "try Again", "ok");
        }



    }
}
