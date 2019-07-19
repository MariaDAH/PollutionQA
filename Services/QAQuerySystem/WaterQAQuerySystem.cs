using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PollutionQA.Models.DTOs;
using PollutionQA.Services.Util;

namespace PollutionQA.Services.QAQuerySystem
{
    public class WaterQAQuerySystem : IQAQuerySystem
    {
        private readonly HttpClient Client;

        public WaterQAQuerySystem(IConfiguration configuration)
        {
            //No authentication
            this.Client = new HttpClient();
            //Read from configuration settings
            var systemConfig = configuration.GetSection("WaterSystem");
            var api_uri = systemConfig.GetValue<string>("APIurl");
            this.Client.BaseAddress = new System.Uri(api_uri);
            this.Client.DefaultRequestHeaders.Accept.Clear();
            this.Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<byte[]> GetAllCitiesByCountryCodeAsync(string countryCode)
        {
           byte[] payload = {};
            UriBuilder builder = new UriBuilder($"{this.Client.BaseAddress}/cities");
            builder.Query = $"country={countryCode}";
            HttpResponseMessage response = await this.Client.GetAsync(builder.Uri);
            if (response.IsSuccessStatusCode)
            {
                payload = await response.Content.ReadAsByteArrayAsync();
            }
            return payload;
        }

        public async Task<byte[]> GetAllCountriesAsync()
        {
            byte[] countries = {};
            UriBuilder builder = new UriBuilder($"{this.Client.BaseAddress}/countries");
            HttpResponseMessage response = await this.Client.GetAsync(builder.Uri);
            if (response.IsSuccessStatusCode)
            {
                countries = await response.Content.ReadAsByteArrayAsync();
            }
            //this.CountryList = JsonConvert.DeserializeObject<List<Country>>(Encoding.UTF8.GetString(countries));
            return countries;
        }

        public async Task<IEnumerable<QueryResult>> GetMeassurementsByCityAsync(QueryDetails details)
        {
            List<QueryResult> queryresults = new List<QueryResult>();
            byte[] results = {};
            UriBuilder builder = new UriBuilder($"{this.Client.BaseAddress}/measurements");
            builder.Query = $"country={details.CountryCode}";
            builder.Query += $"&city={details.City}";
            if(details.Parameter!=null)
            {
                for(int i=0; i < details.Parameter.Length; i++)
                {
                    builder.Query += $"&parameter={details.Parameter[i]}";
                }
            }
            HttpResponseMessage response = await this.Client.GetAsync(builder.Uri);
            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsByteArrayAsync();
            }

            queryresults = JsonUtils.ConvertToDTO<QueryResult>(results);

            return queryresults;
        }

        public async Task<byte[]> GetAllParametersAsync()
        {
            byte[] parameters = {};
            UriBuilder builder = new UriBuilder($"{this.Client.BaseAddress}/parameters");
            HttpResponseMessage response = await this.Client.GetAsync(builder.Uri);
            if (response.IsSuccessStatusCode)
            {
                parameters = await response.Content.ReadAsByteArrayAsync();
            }
            return parameters;
        }
    }

}