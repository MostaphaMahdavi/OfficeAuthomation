using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.Domains.Accounts.Users.Entities;

namespace OfficeAuthomation.Domains.Accounts.Users.Repositories
{
    public interface IUserRepositoryCommand
    {
        Task ActiveOrDeactiveUser(string userId);

        
        

    }
}