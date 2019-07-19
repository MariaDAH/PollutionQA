using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json.Linq;

using PollutionQA.Services.QAQuerySystem;
using PollutionQA.Models;
using PollutionQA.Models.DTOs;
using Microsoft.Extensions.Configuration;

namespace PollutionQA.Controllers
{
    public class HomeController : Controller
    {
        private readonly QueryContext Context_;
        private readonly IConfiguration configuration_;

        public HomeController(QueryContext context, IConfiguration configuration)
        {
            Context_=context;
            this.configuration_ = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {  
            var model = new IndexViewModel();
            ConfigureViewModel(model);
			return View(model);
        }

        [HttpPost]
		public ActionResult Index(IndexViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ConfigureViewModel(model);
				return View(model);
			}

            var redirect = string.Empty;
            switch(model.SelectedStrategyId)
            {
                case 1: 
                    redirect = "ControlPanel";
                    Context_.SetQAStrategy(new AirQAQuerySystem(this.configuration_));
                    Context_.SetTitle("Air System");
                    break;
                case 2:
                    redirect = "ControlPanel";
                    Context_.SetQAStrategy(new WaterQAQuerySystem(this.configuration_));
                    Context_.SetTitle("Water System");
                    break;
                case 3:
                    redirect = "ControlPanel";
                    Context_.SetQAStrategy(new RadioactivityQAQuerySystem());
                    Context_.SetTitle("Radioactivity System");
                    break;
            }

            return RedirectToAction(redirect);
		}
        
        private void ConfigureViewModel(IndexViewModel model)
		{
			IEnumerable<Strategy> _strategies = Repository.FetchStrategies();
			model.Strategies = new SelectList(_strategies, "ID", "Name");
		}

        public IActionResult Privacy()
        {  
			return View();
        }

        [HttpGet]
        public async Task<IActionResult> ControlPanel()
        {      
            var model = new SelectQueryDetailsViewModel();

            model.Title = Context_.GetTitle();

            var countries = new List<string>();

            var cities = new List<string>();

            //Load all countries

            var result = await Context_.GetAllCountriesAsync();

            countries = Context_.Countries.Select(x => x.Value).ToList();

            model.Countries = GetSelectListItems(countries);

            ViewData["Countries"] = model.Countries;

            //Get cities, intially will be empty as no country selected.

            model.Cities = GetSelectListItems(cities);

            ViewData["Cities"] = model.Cities;

            //Select Parameters

            var parameters = await SelectParameters();

            model.Parameters = GetSelectListItems(parameters);

            //Initialize query results from view model
    
            var queryresult = new List<QueryResult>();

            model.QueryResults = queryresult.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ControlPanel(SelectQueryDetailsViewModel model)
        {
            var countries = new List<string>();
            countries = Context_.Countries.Select(x => x.Value).ToList();
            model.Countries = GetSelectListItems(countries);

            if(!string.IsNullOrEmpty(model.Country))
            {
                var parameters = new List<string>();
                model.Parameters = GetSelectListItems(parameters);
                var cities = new List<string>();
                var code = Context_.GetCodeByCountryName(model.Country);
                cities = await GetCitiesByCountry(code);
                model.Cities = GetSelectListItems(cities);

                if(!string.IsNullOrEmpty(model.City))
                {
                    model.Parameters = GetSelectListItems(parameters);
                }
            }

            var details = Context_.PrepareQuery(model.Country, model.City, model.Parameter);
            model.QueryResults = await ShowResults(details);
        
           return View(model);
           //return Redirect("/Home/ControlPanel");
        } 
        
        public async Task<IEnumerable<string>> SelectParameters()
        {
            var parameters = new List<string>();
            var result = await this.Context_.GetAllParametersAsync();
            JObject params_ = JObject.Parse(Encoding.UTF8.GetString(result));
            var listparams = params_["results"];
            parameters = listparams.ToObject<List<Parameter>>().Select(x => x.Id).ToList();
            return parameters;
        }
        
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        
        public async Task<List<string>> GetCitiesByCountry(string code)
        {
            var cities = new List<string>();

            //Load cities depending selected country otherwise empty list
            if(!string.IsNullOrEmpty(code))
            {
                var citiesList = await Context_.GetAllCitiesByCountryCodeAsync(code);

                JObject jsonCities = JObject.Parse(Encoding.UTF8.GetString(citiesList));

                var results_ = jsonCities["results"];

                cities = results_.ToObject<List<City>>().Select(x => x.city).ToList();
            }
            
            return cities;
        }
            
        public async Task<List<QueryResult>> ShowResults(QueryDetails details)
        {   
            var queryresult = await Context_.GetMeassurementsByCityAsync(details);
            return queryresult.ToList();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
