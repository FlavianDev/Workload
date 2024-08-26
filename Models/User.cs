using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkloadApp.Models
{
    public class User
    {
        [Key, Required, Display(Name = "ID")]
        public string UserId { get; set; }
        public string PassHash { get; set; }
        public string UserEmail { get; set; }
        [Display(Name = "Is Freelancer")]
        public bool IsFreelancer { get; set; }
    }
}
