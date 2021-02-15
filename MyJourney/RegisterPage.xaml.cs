using MyJourney.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyJourney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {


        RegisterVM viewModel;
        public RegisterPage()
        {
            InitializeComponent();

            viewModel = new RegisterVM();
            BindingContext = viewModel;
        }
        //private async void registerButton_Clicked(object sender, EventArgs e)
        //{
        //    if (passwordentry.Text == ConfirmPasswordEntry.Text)
        //    {

        //        Users.Register(users);
        //        //var message = "You are being registered" +"May take Time" +
        //        //    "Due to Coronavirus Panddemic";

        //        //DependencyService.Get<Imessage>().longTime(message);
        //        //await App.MobileService.GetTable<Users>().InsertAsync(users);

        //        //await DisplayAlert("Hurray", "You will registered in less than 30 Seconds", "ok");

        //    }
        //    else {

        //        await DisplayAlert("heyERROR", "hmm same pls", "ok");
        //}
        //}
    }
}

