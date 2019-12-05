using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using UserAdmin.Data.Entities;

namespace UserAdmin.Data
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly UserContext _ctx;
        private readonly ILogger<ProfileRepository> _logger;

        public ProfileRepository(UserContext ctx, ILogger<ProfileRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public ICollection<UserProfile> GetAllUserProfile()
        {
            return _ctx.UserProfile.ToList();
        }
    }
}
