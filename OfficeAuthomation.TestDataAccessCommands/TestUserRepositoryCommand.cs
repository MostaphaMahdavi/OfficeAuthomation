using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using System;
using System.Threading.Tasks;
using OfficeAuthomation.DataAccessCommands.Context;
using Xunit;

namespace OfficeAuthomation.TestDataAccessCommands
{
    public class TestUserRepositoryCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly OfficeAuthomationContext _context;

        public TestUserRepositoryCommand(UserManager<User> userManager, OfficeAuthomationContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Fact(Skip = "")]
        public async Task Should_AddUser()
        {
            User user = new User()
            {
                ShamsiBirthDate = "1399/01/01",
                SignaturePath = "sss.png",
                ImagePath = "ss.png",
                IsActive = true,
                RoleAdmin = 1,
                FirstName = "Mostapha",
                LastName = "Mahdavi",
                Gender = 1,
                UserName = "Mostapha1",
                PersonalCode = "1234567890",
                Address = "Aaaa",
                PhoneNumber = "09127996346",
                Email = "ww@ff.com",
                BirthDate = new DateTime(1989, 05, 13),
                RegisterDate = DateTime.Now,
                MeliCode = "4240013704"
                
                
            };


            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                Assert.Equal("Success", result.Succeeded.ToString());
            }
            else
            {
                Assert.Equal("Errors", result.Errors.ToString());
            }


        }


        [Fact(Skip = "")]

        public async Task Should_ActiveOrDeactiveUser()
        {
            var userId = "1223";
            var user = await _context.Users.FindAsync(userId);

            user.IsActive = !user.IsActive;

            if (user==null)
            {
               Assert.True(false);
            }
            else
            {
                Assert.False(true);
            }

        }
    }
}
