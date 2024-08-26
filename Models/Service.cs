using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data.Enums;

namespace WorkloadApp.Models
{
    public class Service
    {
        [Key, Required, Display(Name = "ID")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Required")]
        public int FreelancerId { get; set; }
        [Display(Name = "Poza")]
        public string ServicePicURL { get; set; }
        [Required(ErrorMessage = "Required"), MaxLength(30, ErrorMessage = "Max of 30 characters"), Display(Name = "Nume")]
        public string ServiceName { get; set; }
        [MaxLength(100, ErrorMessage = "Max of 100 characters"), Display(Name = "Descriere")]
        public string ServiceDescription { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Unitate de masura")]
        public UM ServiceUM { get; set; }
        [Display(Name = "Pret")]
        public double ServicePrice { get; set; }
        [Display(Name = "Activ")]
        public bool ServiceActive { get; set; }

        //Relationships
        [Display(Name = "Oras(e)")]
        public List<City_Service> Cities_Services { get; set; }
        [ForeignKey("FreelancerId")]
        public Freelancer Freelancer { get; set; }
    }
}
