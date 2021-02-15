using MyJourney.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyJourney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;
        public HomePage()
        {
            InitializeComponent();

            viewModel = new HomeVM();
            BindingContext = viewModel;
        }


    }
}