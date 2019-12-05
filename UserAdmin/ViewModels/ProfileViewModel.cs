using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAdmin.ViewModels
{
    public class ProfileViewModel
    {
        public int ProfileProfileId { get; set; }
        [Required]
        public string ProfileProfileDescription { get; set; }
    }
}
