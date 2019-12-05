using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _ctx;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(UserContext ctx, ILogger<UserRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }


        public ICollection<User> GetAllUsers()
        {
            return _ctx.Users
                       .ToList();
        }

        public ICollection<User> GetActiveUsers(bool state)
        {
            return _ctx.Users
                .Include(u => u.Profile)
                .Where(u => u.Active == state)
                       .ToList();

        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public User GetUserById(int id)
        {
            return _ctx.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }
        
        public void SaveChanges(object model)
        {
            _ctx.Add(model);
        }
        
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
        
        public async Task<bool> UpdateUserAsync(User model)
        {
            _ctx.Users.Update(model);
            _ctx.Entry(model).State = EntityState.Modified;

            try
            {
                return (await _ctx.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(UpdateUserAsync)}: " + exp.Message);
            }
            return false;
        }


    }
}
