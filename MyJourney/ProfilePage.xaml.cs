using MyJourney.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyJourney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }



        protected override async void OnAppearing()
        {
            //base.OnAppearing();
            //var message = "You are directed to Profile Page where u will be able to see your places details";

            //DependencyService.Get<Imessage>().longTime(message);

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //var postTable  = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.users.Id).ToListAsync();
                var postTable = await Post.Read();

                var categoriesCount = Post.PostCategories(postTable);

                //Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                //foreach (var category in categories)
                //{
                //    var count = (from post in postTable
                //                 where post.CategoryName == category
                //                 select post).ToList().Count;

                //    var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                //    categoriesCount.Add(category, count2);
                //}

                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}
