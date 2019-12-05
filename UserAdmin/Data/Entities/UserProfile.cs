using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAdmin.Data.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string ProfileDescription { get; set; }

        //public ICollection<User> users { get; set; }
    }
}
