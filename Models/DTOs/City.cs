using System;
using Newtonsoft.Json;

namespace PollutionQA.Models.DTOs
{
    /// <summary>
    /// </summary>
    public class City
    {
        public string city { get; set; }
        
        public string country { get; set; }
        //Property member indicating number of meassurement for the city
        public int Count { get; set; } 


        public override bool Equals(object obj) {

            City target = (City)obj;

            return (this.city == target.city) &&
                   (this.country == target.country) &&
                   (this.Count == target.Count);
        }

        public override int GetHashCode(){
            return this.city.GetHashCode();
        }

        public override string ToString() {

            string strCountry = "[ Code = " + this.country + " | " +
                "Name = " + this.city + " | " +
                "Count = " + this.Count + " ] " ;

            return strCountry;
        }
    }
}