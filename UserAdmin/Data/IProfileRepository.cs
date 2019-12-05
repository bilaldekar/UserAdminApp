using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public interface IProfileRepository
    {
        ICollection<UserProfile> GetAllUserProfile();
    }
}
