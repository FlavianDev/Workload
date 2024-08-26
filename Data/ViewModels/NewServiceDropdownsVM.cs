using System.Collections.Generic;
using WorkloadApp.Models;

namespace WorkloadApp.Data.ViewModels
{
    public class NewServiceDropdownsVM
    {
        public NewServiceDropdownsVM()
        {
            Cities = new List<City>();
        }
        public List<City> Cities { get; set; }
    }
}
