using System.ComponentModel.DataAnnotations;

namespace WorkloadApp.Data.ViewModels
{
    public class FreelancerVM
    {
        public string ProfilePicURL { get; set; }
        [Required(ErrorMessage = "Required"), MaxLength(30, ErrorMessage = "Max of 30 characters"), Display(Name = "Freelancer Name")]
        public string FreelancerName { get; set; }
        [MaxLength(100, ErrorMessage = "Max of 100 characters"), Display(Name = "Biography")]
        public string FreelancerBio { get; set; }
    }
}
