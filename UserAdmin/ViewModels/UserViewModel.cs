using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        public string UserUserName { get; set; }
        public string UserEmail { get; set; }
        public bool UserActive { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
