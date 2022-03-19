using Microsoft.EntityFrameworkCore;
using Users.MOdels;

namespace Users.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt):base(opt)
        {
            
        }
        public DbSet<User> Users {get;set;}
    }
}