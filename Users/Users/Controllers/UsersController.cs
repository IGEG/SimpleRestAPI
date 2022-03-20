using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
      
        [HttpGet]
        public ActionResult<IEnumerable<UserMapper>> GetAllUser()
        {
            var UserList = repository.GetAllUsers();
            return Ok(mapper.Map<IEnumerable<UserMapper>>(UserList));
        }
        [HttpGet("{Id}", Name=nameof(GetUserById))]
        public ActionResult<UserMapper> GetUserById(long Id)
        {
            var user = repository.GetUserById(Id);
            if(user!=null)
            {
            return Ok(mapper.Map<UserMapper>(user));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserMapper> CreateUser(CreateUserMapper createUserMapper)
        {
            var user = mapper.Map<User>(createUserMapper);
            repository.CreateUser(user);
            repository.SaveChanges();
            var usermapper = mapper.Map<UserMapper>(user);
            return CreatedAtRoute(nameof(GetUserById),new {Id=usermapper.Id}, usermapper);
           

        }
        //PUT
        [HttpPut("{Id}")]
        public ActionResult UpdateUser (long Id, UpdateUserMapper updateUserMapper)
        {
            var user = repository.GetUserById(Id);
            if(user==null)
            {
                return NotFound();
            }
            mapper.Map(updateUserMapper,user);
            repository.UpdateUser(user);
            repository.SaveChanges();
            return NoContent();

        }
        //PATCH
        [HttpPatch("{Id}")]
        public ActionResult PatchUpdateUser (long Id, JsonPatchDocument<UpdateUserMapper> patchUserMapper)
        {
            var user = repository.GetUserById(Id);
            if(user==null)
            {
                return NotFound();
            }
            var userPatch = mapper.Map<UpdateUserMapper>(user);
            patchUserMapper.ApplyTo(userPatch,ModelState);
            if(!TryValidateModel(userPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(userPatch,user);
            repository.UpdateUser(user);
            repository.SaveChanges();
            return NoContent();
        }
        //DELETE
        [HttpDelete("{Id}")]
        public ActionResult DeleteUser(long Id)
        {
             var user = repository.GetUserById(Id);
            if(user==null)
            {
                return NotFound();
            }
            repository.DeleteUser(user);
            repository.SaveChanges();
            return NoContent();
        }

    }
}