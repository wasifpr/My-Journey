﻿using MyJourney.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyJourney.Model
{

    //public class Meta
    //{
    //    public int code { get; set; }
    //    public string requestId { get; set; }
    //}

    //public class LabeledLatLng
    //{
    //    public string label { get; set; }
    //    public double lat { get; set; }
    //    public double lng { get; set; }
    //}

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }

        public int distance { get; set; }
        public string cc { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string crossStreet { get; set; }
    }

    //public class Icon
    //{
    //    public string prefix { get; set; }
    //    public string suffix { get; set; }
    //}

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        //public Icon icon { get; set; }
        public bool primary { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }

        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();
            var url = VenueRoot.GenerateURL(latitude, longitude);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>;
            }
            return venues;
        }
    }

    public class Response
    {
        public IList<Venue> venues { get; set; }

    }



    public class VenueRoot
    {

        public Response response { get; set; }

        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(Constants.VENUE_SEARCH, latitude, longitude, Constants.CLIENT_ID,
                Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }

        //internal static object GenerateURL(double latitude, object longitude)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
