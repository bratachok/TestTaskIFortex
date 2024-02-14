using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private ApplicationDbContext context;
        public UserService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<User> GetUser()
        {
            User result = context.Users.Where(p => p.Id == context.Orders
            .GroupBy(o => o.UserId)
            .OrderByDescending(o => o.Count())
            .First().Key).First();

            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> result = context.Users.Where(p => p.Status == Enums.UserStatus.Inactive).ToList();
            return result;
        }
    }
}
