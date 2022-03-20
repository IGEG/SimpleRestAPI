using System.Collections.Generic;
using Users.MOdels;

namespace Users.Data 
{
  public interface IUsersRepository
    {
         IEnumerable<User> GetAllUsers ();
         User GetUserById (long Id);
         void CreateUser (User user);
         bool SaveChanges();
        
    }
}