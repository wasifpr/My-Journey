using Android.Widget;
using MyJourney.Helpers;

namespace MyJourney.Droid
{
    public class messege_Driod : Imessage
    {
        public void longTime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void shortTime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }

}