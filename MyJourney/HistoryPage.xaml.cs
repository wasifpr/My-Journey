using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyJourney.Model;
using MyJourney.ViewModel;
using MyJourney.Helpers;
using System.Configuration;
namespace MyJourney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {

        HistoryVM viewModel;

        public HistoryPage()
        {
            InitializeComponent();
            viewModel = new HistoryVM();
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //var message = "You in History page";

            //DependencyService.Get<Imessage>().shortTime(message);

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{

            //    conn.CreateTable<Post>();
            //    var posts = conn.Table<Post>().ToList();

            //    postlv.ItemsSource = posts;

            //}
            //var messagea = "We Getting Your Details";

            //DependencyService.Get<Imessage>().shortTime(messagea);

            //var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.users.Id).ToListAsync();
            //viewModel.Posts.Clear();
            //var   posts = await Post.Read();
            //foreach (var post in posts)
            //    viewModel.Posts.Add(post);

            viewModel.UpdatePosts();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var post = (Post)((MenuItem)sender).CommandParameter;
            viewModel.DeletePost(post);
        }

        private async void postListView_Refreshing(object sender, EventArgs e)
        {
          await   viewModel.UpdatePosts();
            postlv.IsRefreshing = false;

            //await AzureAppServiceHelper.SyncAsync();
        }

      
    }


}