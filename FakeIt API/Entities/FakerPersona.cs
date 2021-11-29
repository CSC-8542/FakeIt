


using System;
using System.Collections.Generic;

namespace FakeIt_API.Entities
{
    public class FakerPersona
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Address
        {
            public string street { get; set; }
            public string streetName { get; set; }
            public string buildingNumber { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public string country { get; set; }
            public string county_code { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class Datum
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }
            public Address address { get; set; }
            public string website { get; set; }
            public string image { get; set; }
        }

        public class Root
        {
            public string status { get; set; }
            public int code { get; set; }
            public int total { get; set; }
            public List<Datum> data { get; set; }
        }


    }
}
