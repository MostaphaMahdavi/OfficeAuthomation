using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace OfficeAuthomation.DataAccessQueries.Accounts.Users.Repositories
{
    public class UserRepositoryQuery : IUserRepositoryQuery
    {
        private readonly SqlConnection _context;

        public UserRepositoryQuery(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }


        public async Task<List<User>> GetAllUser()
        {
            return (await _context.QueryAsync<User>("select * from users")).ToList();
            
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _context.QueryFirstOrDefaultAsync<User>("select * from users where id=@userId",new{ @userId = userId});
        }


    }
}