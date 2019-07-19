using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PollutionQA.Models.DTOs;


namespace PollutionQA.Services.QAQuerySystem
{
    public class QueryContext {
        
        private  IQAQuerySystem _querySystem;  

        public List<KeyValuePair<string,string>> Countries { get; set; }

        private string Title;
        
        public void SetQAStrategy(IQAQuerySystem querySystem)
        {
            _querySystem = querySystem;
        }

        public void SetTitle(string title)
        {
            this.Title = title;
            
        }
        
        public string GetTitle()
        {
            return this.Title;
        }

        public async Task<byte[]> GetAllCountriesAsync()
        {
            var result = await _querySystem.GetAllCountriesAsync();
            GetCountriesPairList(result);
            return result;
        }

        public async Task<byte[]> GetAllCitiesByCountryCodeAsync(string countryCode)
        {
            var result = await _querySystem.GetAllCitiesByCountryCodeAsync(countryCode);

            return result;
        }

        public async Task<byte[]> GetAllParametersAsync()
        {
            var result = await this._querySystem.GetAllParametersAsync();

            return result;
        }

        public async Task<IEnumerable<QueryResult>> GetMeassurementsByCityAsync(QueryDetails details)
        {
            var result = await _querySystem.GetMeassurementsByCityAsync(details);

            return result;
        }

        public QueryDetails PrepareQuery(string countryName, string city, string[] parameters)
        {
            QueryDetails details = new QueryDetails();
            var countryCode =  GetCodeByCountryName(countryName);
            details.CountryCode = countryCode;
            details.City = city;
            details.Parameter = parameters;
            return details;
        }

        public string GetCodeByCountryName(string countryName)
        {
            if(string.IsNullOrEmpty(countryName))
            {
                return string.Empty;
            }
            var countryCode = this.Countries.Where(x => x.Value==countryName).Select(y => y.Key).First();
            return countryCode; 
        }

        public void GetCountriesPairList(byte[] countries)
        {
            JObject json = JObject.Parse(Encoding.UTF8.GetString(countries));

            var results = json["results"];

            var result = results.ToObject<List<Country>>().Select(x => (x.Code, x.Name)).ToList();

            var pairsList = new List<KeyValuePair<string,string>>();

            result.ForEach(x => pairsList.Add(new KeyValuePair<string,string>(x.Item1, x.Item2)));

            this.Countries = pairsList;
        }
    }
}