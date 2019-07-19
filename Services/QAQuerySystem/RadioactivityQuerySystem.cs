using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PollutionQA.Models.DTOs;


namespace PollutionQA.Services.QAQuerySystem
{
    public class RadioactivityQAQuerySystem : IQAQuerySystem
    {
        Task<byte[]> IQAQuerySystem.GetAllCitiesByCountryCodeAsync(string countryCode)
        {
            throw new System.NotImplementedException();
        }

        Task<byte[]> IQAQuerySystem.GetAllCountriesAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<QueryResult>> IQAQuerySystem.GetMeassurementsByCityAsync(QueryDetails details)
        {
            throw new System.NotImplementedException();
        }

        
        string GetCodeByCountryName(string countryName)
        {
             throw new System.NotImplementedException();
        }

        Task<byte[]> IQAQuerySystem.GetAllParametersAsync()
        {
            throw new System.NotImplementedException();
        }
    }

}