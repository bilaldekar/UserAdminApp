using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAdmin.Data;
using UserAdmin.Data.Entities;
using UserAdmin.ViewModels;

namespace UserAdmin.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _repository;
        private readonly ILogger<UsersController> _loger;
        private readonly IMapper _mapper;

        public ProfileController(IProfileRepository repository, ILogger<UsersController> loger, IMapper mapper)
        {
            _repository = repository;
            _loger = loger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<ICollection<UserProfile>> GetProfile()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<UserProfile>, IEnumerable<ProfileViewModel>>(_repository.GetAllUserProfile()));
            }
            catch (Exception e)
            {
                _loger.LogError($"failed {e}");
                return BadRequest("Failed to get profiles");
            }
        }
    }
}