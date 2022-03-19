using System.Collections.Generic;
using System.Linq;
using Users.MOdels;

namespace Users.Data
{
public class EFUserRepository:IUsersRepository
{
    private readonly UserDbContext context;
    public EFUserRepository(UserDbContext cont)
    {
        context = cont;
    }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(long Id)
        {
            return context.Users.FirstOrDefault(u=>u.Id==Id);
        }
    }
}