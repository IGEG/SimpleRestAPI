using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Users.Data;
using Users.MOdels;

namespace Users.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MockUserRepository mock = new MockUserRepository();
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUser()
        {
            var UserList = mock.GetAllUsers();
            return Ok(UserList);
        }
        [HttpGet("{Id}")]
        public ActionResult<User> GetUserById(long Id)
        {
            var user = mock.GetUserById(Id);
            return Ok(user);
        }

    }
}