using System.Collections.Generic;
using System.Threading.Tasks;

using PollutionQA.Models.DTOs;

namespace PollutionQA.Services.QAQuerySystem
{
    public interface IQAQuerySystem
    {
        Task<byte[]> GetAllCountriesAsync();

        Task<byte[]> GetAllCitiesByCountryCodeAsync(string countryCode);

        Task<IEnumerable<QueryResult>> GetMeassurementsByCityAsync(QueryDetails details);

        Task<byte[]> GetAllParametersAsync();

    }
}