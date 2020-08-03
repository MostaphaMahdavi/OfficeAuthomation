using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeAuthomation.DataAccessQueries.Accounts.Users.Repositories;
using Xunit;

namespace OfficeAuthomation.TestDataAccessQueries
{


    public class TestUserRepositoryQuery
    {
        private readonly SqlConnection _db;
        private readonly IConfiguration _configuration;
        public TestUserRepositoryQuery(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);

        }


        [Fact]
        public void Should_GetAllUser()
        {
            UserRepositoryQuery user = new UserRepositoryQuery(_configuration);

            var result = user.GetAllUser();

            Assert.NotEmpty(result.Result);
        }


    }
}
