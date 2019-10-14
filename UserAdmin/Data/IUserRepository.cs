using System.Collections.Generic;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        ICollection<User> GetActiveUsers();
        
        User GetUserById(int id);

        void AddEntity(object model);

        bool SaveAll();
        void SaveChanges(object model);
        Task<bool> UpdateUserAsync(User newUser);

    }
}