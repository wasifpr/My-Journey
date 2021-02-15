using MyJourney.Model;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyJourney
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();




        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //var message = "You are directed to Map Page Upading Details";

            //DependencyService.Get<Imessage>().longTime(message);

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;

            //DateTime dt1 = DateTime.Now;
            //DateTime dt2 = DateTime.Now;
            //TimeSpan ts = dt1 - dt2;

            //await locator.StartListeningAsync(ts, 100);
            await locator.StartListeningAsync(TimeSpan.FromMinutes(0), 100);


            var postion = await locator.GetPositionAsync();

            //to avoid allredy listening exception here 






            //var span = new Xama  rin.Forms.Maps.MapSpan(center, 2, 2); 
            //var center = new Xamarin.Forms.Maps.Position(`position.Latitude,postion.Logitude);
            //LocationMap.MoveToRegion(span);


            LocationMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(postion.Latitude, postion.Longitude), 2, 2));


            /*  using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
              {

                  conn.CreateTable<Post>();
                  var posts = conn.Table<Post>().ToList();

                  DisplayInMap(posts);

              }
              */
            //await locator.StopListeningAsync();
            //var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.users.Id).ToListAsync();

            var posts = await Post.Read();
            DisplayInMap(posts);

        }
        protected async override void OnDisappearing()
        {
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();
        }


        private void DisplayInMap(List<Post> posts)
        {
            foreach (var post in posts)


            {

                try
                {


                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address

                    };

                    LocationMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre) { }
                catch (Exception e) { }
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {


            //var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude,e.Position.Longitude);
            //var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            //LocationMap.MoveToRegion(span);
        }
    }
}