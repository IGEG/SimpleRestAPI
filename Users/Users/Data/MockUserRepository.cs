using System.Collections.Generic;
using Users.MOdels;

namespace Users.Data
{
public class MockUserRepository : IUsersRepository
{
        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
    {
        var users = new List<User>
{
   new User {Id=0, FName="First0", LName="Last0", Adress="Street0"},
   new User {Id=1, FName="First1", LName="Last1", Adress="Street1"},
   new User {Id=2, FName="First2", LName="Last2", Adress="Street2"}
};
        return users;
    }

    public User GetUserById(long Id)
    {
        return new User { Id = 0, FName = "First0", LName = "Last0", Adress = "Street0" };
    }

        bool IUsersRepository.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}