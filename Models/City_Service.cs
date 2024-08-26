using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkloadApp.Models
{
    public class City_Service
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
