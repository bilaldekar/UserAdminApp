using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAdmin.Data;
using UserAdmin.Data.Entities;
using UserAdmin.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace UserAdmin.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _repository;
        private readonly ILogger<UsersController> _loger;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, ILogger<UsersController> loger, IMapper mapper)
        {
            _repository = repository;
            _loger = loger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<ICollection<User>> GetActiveUsers(bool state)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable< User>, IEnumerable<UserViewModel>>(_repository.GetActiveUsers(state)));
            }
            catch (Exception e)
            {
                _loger.LogError($"failed {e}");
                return BadRequest("Failed to get users");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            try
            {
                var user = _repository.GetUserById(id);

                if (user != null)
                {
                    return Ok(_mapper.Map<User, UserViewModel> (user));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _loger.LogError($"failed {e}");
                return BadRequest("Failed to get user");
            }
        }



        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel model )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = _mapper.Map<UserViewModel, User>(model);

                    _repository.AddEntity(newUser);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/users/{newUser.Id}", _mapper.Map<User, UserViewModel>(newUser));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }            
            catch (Exception e)
            {
                _loger.LogError($"failed to save user {e}");
            }

            return BadRequest("Failed to save new user");
        }


        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        //[ProducesResponseType(typeof(ApiResponse), 200)]
        //[ProducesResponseType(typeof(ApiResponse), 400)]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Put(int id, [FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("failed to edit user");
            }

            try
            {
                
                var user = _mapper.Map<UserViewModel, User>(model);
                var status = await _repository.UpdateUserAsync(user);
                if (!status)
                {
                    return BadRequest("failed to edit user");
                }
                return Ok(_mapper.Map<User, UserViewModel>(user));
            }
            catch (Exception exp)
            {
                _loger.LogError(exp.Message);
                return BadRequest("failed to edit user");
            }
        }


    }
}