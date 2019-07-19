using System;

namespace PollutionQA.Models.DTOs
{
    [Serializable()]
    public class QueryDetails {
        
        public string CountryCode { get; set; }

        public string City { get; set; }

        public string Location { get; set; }

        public string[] Parameter { get; set; }

        public bool Has_Geo { get; set; }

        public Coordinates Coordinates { get; set; }

        public int Radius { get; set; }

        public int Value_from { get; set; }

        public int Value_to { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string[] OrderBy { get; set; }

        public string[] Sort { get; set; }

        public Array Include_Fields { get; set; }

        public int Limit { get; set; }

        public int Page { get; set; }

        public string Format { get; set; }

    }

    enum Include_Fields
    {
        attribution ,
        averagingPeriod, 
        sourceName
    }
}