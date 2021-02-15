 
using MyJourney.Model;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyJourney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        Post post;
        public NewTravelPage()
        {
            InitializeComponent();
            post = new Post();
            cointainerStackLayout.BindingContext = post;
        }

        [Obsolete]
        protected override async void OnAppearing()
        {




            base.OnAppearing();
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Location))
                    {
                        await DisplayAlert("Need Permission", "Need location Acesss to show Map" +
                            "Give Location Acess and restart app ", "ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    if (results.ContainsKey(Permission.Location))
                    {
                        status = results[Permission.Location];
                    }
                }
                if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {


                    var locator = CrossGeolocator.Current;
                    var postion = await locator.GetPositionAsync();


                    var venues = await Venue.GetVenues(postion.Latitude, postion.Longitude);

                    venueListView.ItemsSource = venues;
                }
                else
                {
                    await DisplayAlert("NO Permission Granted", " You should give permission to this application for Location", "ok");
                }
            }
            catch (Exception ex) { }
        }
        //private  async void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var selectedVenue = venueListView.SelectedItem as Venue;
        //        //var firstCategories = selectedVenue.categories.FirstOrDefault();





        //        //Post.CategoryId = firstCategories.id;
        //        //Post.CategoryName = firstCategories.name;
        //        //Post.Address = selectedVenue.location.address;
        //        //Post.Distance = selectedVenue.location.distance;
        //        //Post.Latitude = selectedVenue.location.lat;
        //        //Post.Longitude = selectedVenue.location.lng;
        //        //Post.VenueName = selectedVenue.name;
        //        //Post.UserId = App.users.Id;




        //        //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //        //{
        //        //    conn.CreateTable<Post>();


        //        //    int rows = conn.Insert(post);

        //        //    conn.Close();
        //        //    if (rows > 0)
        //        //    {
        //        //        DisplayAlert("Success", "Experince saved", "thank  you");

        //        //    }
        //        //    else
        //        //    { 
        //        //        DisplayAlert("failed", "Restart the app", "ok thanks");
        //        //    }
        //        //}

        //        //var message = "Your Location and venue details will be saved ";

        //        //DependencyService.Get<Imessage>().shortTime(message);
        //        Post.Insert(post);
        //        //await App.MobileService.GetTable<Post>().InsertAsync(post);
        //    await DisplayAlert("Success", "Experince saved", "thank  you");
        //        //var messagea = "Your Location is saved and availiable on history and  map Page";

        //        //DependencyService.Get<Imessage>().shortTime(messagea);

        //    }
        //    catch (NullReferenceException nre)
        //    {
        //     await  DisplayAlert("failed", "Restart the app " +
        //         "may be Internet" +
        //         "is not working fine", "ok thanks");

        //    }
        //    catch (Exception ex)
        //    { }

        //}
    }
}