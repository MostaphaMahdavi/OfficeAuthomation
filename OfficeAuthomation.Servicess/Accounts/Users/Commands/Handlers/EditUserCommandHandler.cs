using System.Linq;
using MediatR;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using OfficeAuthomation.Domains.Enums;
using OfficeAuthomation.Servicess.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using Serilog;

namespace OfficeAuthomation.Servicess.Accounts.Users.Commands.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, ResultStatusType>
    {
        private readonly IUserRepositoryCommand _userRepositoryCommand;
        private readonly IUserRepositoryQuery _userRepositoryQuery;
        private UserManager<User> _userManager;

        public EditUserCommandHandler(IUserRepositoryCommand userRepositoryCommand, IUserRepositoryQuery userRepositoryQuery, UserManager<User> userManager)
        {
            _userRepositoryCommand = userRepositoryCommand;
            _userRepositoryQuery = userRepositoryQuery;
            _userManager = userManager;
        }


        public async Task<ResultStatusType> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PersonalCode = request.PersonalCode;
            user.MeliCode = request.MeliCode;
            user.Address = request.Address;
            user.ShamsiBirthDate = request.ShamsiBirthDate;
            user.Gender = request.Gender;
            user.ImagePath = request.ImagePath;
            user.SignaturePath = request.SignaturePath;
            user.IsActive = request.IsActive == 1 ? true : false;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.BirthDate = ConvertDateTime.ConvertShamsiToMiladi(request.ShamsiBirthDate);
            user.RoleAdmin = request.RoleAdmin;

            //  var result = await _userRepositoryCommand.EditUser(user);

            var result = await _userManager.UpdateAsync(user);

            if (result.Errors.Count() > 0)
            {
                foreach (var error in result.Errors)
                {
                    Log.ForContext("Message", error.Description)
                        .Error($"Error: {error.Description} StatusCode: {error.Code}");

                }
                return ResultStatusType.error;
            }


            if (result.Succeeded)
            {
                return ResultStatusType.success;
            }
            else
            {
                return ResultStatusType.failed;
            }

        }
    }
}
