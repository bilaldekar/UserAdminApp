using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> op) : base(op)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
