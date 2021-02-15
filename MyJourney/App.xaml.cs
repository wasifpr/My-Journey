using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MyJourney.Model;
using System.Net.Http;
using Xamarin.Forms;

namespace MyJourney
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient

        MobileService = new MobileServiceClient("https://myjourneys.azurewebsites.net", new HttpClientHandler());

        public static IMobileServiceSyncTable<Post> postsTable;

        //client = new MobileServiceClient("https://myjourneys.azurewebsites.net", new HttpClientHandler());

        public static Users users = new Users();



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;

            var store = new MobileServiceSQLiteStore(databaseLocation);
            store.DefineTable<Post>();

            MobileService.SyncContext.InitializeAsync(store);
            postsTable = MobileService.GetSyncTable<Post>()  ;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
