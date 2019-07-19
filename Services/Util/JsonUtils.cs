using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

using PollutionQA.Models.DTOs;

namespace PollutionQA.Services.Util
{
    public class JsonUtils
    {
        public static List<QueryResult> ConvertToDTO<T>(byte[] bytes)
        {
            var encoded = System.Text.Encoding.UTF8.GetString(bytes);

            JObject json = JObject.Parse(encoded);

            var results = json["results"];

            var query_results = new List<QueryResult>();

            for(int i=0; i < results.Count() ; i++)
            {
                var queryResult = new QueryResult();
                var location = (string)json["results"][i]["location"];
                var city = (string)json["results"][i]["city"];
                var country = (string)json["results"][i]["country"];
                var parameter = (string)json["results"][i]["parameter"];
                var value = (decimal)json["results"][i]["value"];
                var unit = (string)json["results"][i]["unit"];
                queryResult.City = city;
                queryResult.Location = location;
                queryResult.Value = value;
                queryResult.Country = country;
                queryResult.Parameter = parameter;
                queryResult.Unit = unit;

                query_results.Add(queryResult);
            }

            return query_results;
        }
    }
}