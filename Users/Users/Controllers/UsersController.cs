using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Users.Data;
using Users.MOdels;
using Users.ModelsMapper;

namespace Users.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;
        private readonly IMapper mapper;

        public UsersController(IUsersRepository repo, IMapper map)
        {
            repository=repo;
            mapper=map;
        }
        //private readonly MockUserRepository mock = new MockUserRepository();
        [HttpGet]
        public ActionResult<IEnumerable<UserMapper>> GetAllUser()
        {
            var UserList = repository.GetAllUsers();
            return Ok(mapper.Map<IEnumerable<UserMapper>>(UserList));
        }
        [HttpGet("{Id}")]
        public ActionResult<UserMapper> GetUserById(long Id)
        {
            var user = repository.GetUserById(Id);
            if(user!=null)
            {
            return Ok(mapper.Map<UserMapper>(user));
            }
            return NotFound();
        }

    }
}