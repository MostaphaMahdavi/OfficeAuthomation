using System.Collections.Generic;
using System.Threading.Tasks;
using OfficeAuthomation.Domains.Accounts.Users.Entities;

namespace OfficeAuthomation.Domains.Accounts.Users.Repositories
{
    public interface IUserRepositoryQuery
    {
        Task<List<User>> GetAllUser();

        Task<User> GetUserById(string userId);

    }
}