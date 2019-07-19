using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

using PollutionQA.Models.DTOs;

namespace PollutionQA.Models
{
    public class SelectQueryDetailsViewModel
    {
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Parameter")]
        public string[] Parameter { get; set; }

        public string Title {get; set;}

        public IEnumerable<SelectListItem> Countries { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        public IEnumerable<SelectListItem> Parameters { get; set; }

        public List<QueryResult> QueryResults { get; set;}
    }
}