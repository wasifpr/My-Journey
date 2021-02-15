using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using System.IO;
using UIKit;

namespace MyJourney.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // Users Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("FastRenders_Experimental");
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            CurrentPlatform.Init();


            string dbName = "myjourney_db.sqlite";
            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(folderPath, dbName);



            LoadApplication(new App(fullPath));

            return base.FinishedLaunching(app, options);
        }
    }
}
