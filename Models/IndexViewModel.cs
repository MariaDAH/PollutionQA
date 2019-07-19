using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PollutionQA.Models
{
    public class IndexViewModel
    {    
        public int SelectedStrategyId { get; set; }
        public SelectList Strategies {get; set;}
    }

    public class Strategy
	{
		public int ID { set; get; }
		public string Name { set; get; }
	}
	
	public static class Repository
	{
		public static IEnumerable<Strategy> FetchStrategies()
		{
			return new List<Strategy>()
			{
				new Strategy(){ ID = 1, Name = "Air Pollution"},
				new Strategy(){ ID = 2, Name = "Water Pollution" },
				new Strategy(){ ID = 3, Name = "Radioactivity Pollution" }
			};
		}
	}
}