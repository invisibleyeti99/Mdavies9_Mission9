using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9.Models.ViewModels
{

    public class StoreSales
    {
        [Key]
        [BindNever]
        public int SalesId { get; set; }
        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }
        
        [Required(ErrorMessage = "Please enter a name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a address")]
        public string AddLine1 { get; set; }
        public string AddLine2 { get; set; }
        public string AddLine3 { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state abbrivation")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a zipcode")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
        


    }
}
