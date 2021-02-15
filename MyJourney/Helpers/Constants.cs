using System;

namespace MyJourney.Helpers
{
    public class Constants
    {
        public string D = DateTime.Today.ToString("YYYYMMDD");

        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        public const string CLIENT_ID = "FM4OT43H0FRCEXYALGI103BJHBWDG5EYVTEPG2SITPFNWCTR";
        public const string CLIENT_SECRET = "WCZN22MWG0PZEUCKOQ34AKIN1A0V3BBULFAGYGP1YQ4R2B41";
        //string a  = DateTime.Now.ToString("YYYYMMDD");




    }



}
