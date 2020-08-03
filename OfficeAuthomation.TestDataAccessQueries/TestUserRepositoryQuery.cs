using System.Linq;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using Xunit;

namespace OfficeAuthomation.TestDataAccessQueries
{


    public class TestUserRepositoryQuery
    {
        private SqlConnection _context;

        public TestUserRepositoryQuery()
        {
            _context = new SqlConnection("Server=.;Database=OfficeAuthomation;Uid=sa;Pwd=123;MultipleActiveResultSets=true");
        }


        [Fact]

        public async Task Should_GetAllUser()
        {

            var result = (await _context.QueryAsync<User>("select * from users")).ToList();


            Assert.NotEmpty(result);

        }


        [Fact]
        public async Task should_GetUserById_when_4b58b3db6b8f42ada007fdd77daba989_then_Mostapha()
        {
            var userId = "4b58b3db-6b8f-42ad-a007-fdd77daba989";
            var result =
              await _context.QueryFirstOrDefaultAsync<User>("select * from users where id=@userId", new { @userId = userId });

            Assert.Equal(result.UserName, "Mostapha");


        }

    }
}
