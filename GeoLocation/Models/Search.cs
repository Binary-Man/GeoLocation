using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoLocation.Models
{
    public class Search
    {
        /// <summary>
        /// The search address
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// The located address
        /// </summary>       
        public string Location { get; set; }
    }
}