using System;

namespace PollutionQA.Models.DTOs
{
    [Serializable()]
    public class QueryResult{
        
        public QueryResult(){}

        public string Location { get; set; }

        public string Parameter { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string Unit { get; set; }

        public Coordinates Coordinates { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

    }

    public struct Coordinates
    {
        public double Latitute;
        public double Longitude;

        public Coordinates(double lat, double lon)
        {
            Latitute = lat;
            Longitude = lon;
        }
    }
}