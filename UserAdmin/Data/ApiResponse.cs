using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public User User { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}