using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.DataAccessCommands.Context;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using System.Threading.Tasks;

namespace OfficeAuthomation.DataAccessCommands.Accounts.Users.Repositories
{
    public class UserRepositoryCommand : IUserRepositoryCommand
    {
        private readonly OfficeAuthomationContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepositoryCommand(OfficeAuthomationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task ActiveOrDeactiveUser(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            user.IsActive = !user.IsActive;
            _context.Users.Update(user);
        }

       

 
    }
}