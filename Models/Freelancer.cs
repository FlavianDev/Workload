using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkloadApp.Models
{
    public class Freelancer
    {
        [Key, Required, Display(Name = "ID")]
        public int FreelancerId { get; set; }
        [Required]
        public string UserId { get; set; } 
        [Display(Name= "Profile Picture")]
        public string ProfilePicURL { get; set; }
        [Required(ErrorMessage = "Required"), MaxLength(30, ErrorMessage = "Max of 30 characters"), Display(Name = "Freelancer Name")]
        public string FreelancerName { get; set; }
        [MaxLength(100, ErrorMessage = "Max of 100 characters"), Display(Name = "Biography")]
        public string FreelancerBio { get; set; }

        //Relationships
        public List<Service> Services { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
