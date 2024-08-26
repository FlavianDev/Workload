using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkloadApp.Models
{
    public class City
    {
        [Key, Required]
        public int CityId { get; set; }
        [Required, MaxLength(50)]
        public string CityName { get; set; }

        public List<City_Service> Cities_Services { get; set; }
    }
}
