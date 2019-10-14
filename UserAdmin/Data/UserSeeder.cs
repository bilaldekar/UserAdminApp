using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public class UserSeeder
    {

        private readonly UserContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public UserSeeder(UserContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Users.Any())
            {
                // Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/user.json");
                var json = File.ReadAllText(filepath);
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                _ctx.Users.AddRange(users);
                _ctx.SaveChanges();
            }
        }
    }
}
