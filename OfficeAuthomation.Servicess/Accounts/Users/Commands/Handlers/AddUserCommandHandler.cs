using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Enums;
using OfficeAuthomation.Servicess.Utilities;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OfficeAuthomation.Servicess.Accounts.Users.Commands.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ResultStatusType>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResultStatusType> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                SignaturePath = request.SignaturePath,
                ImagePath = request.ImagePath,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ShamsiBirthDate = request.ShamsiBirthDate,
                BirthDate = ConvertDateTime.ConvertShamsiToMiladi(request.ShamsiBirthDate),
                UserName = request.UserName,
                Gender = request.Gender,
                RoleAdmin = request.RoleAdmin,
                IsActive = true,
                PersonalCode = request.PersonalCode,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                RegisterDate = DateTime.Now,
                MeliCode = request.MeliCode,


            };



            try
            {


                var result = await _userManager.CreateAsync(user, "Mm1qazXSW@3edc");

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
                    Log.ForContext("Message", "AddUserSuccess")
                        .Error($"Ok: {result} StatusCode: {201}");
                    return ResultStatusType.success;
                }

                else
                {
                    Log.ForContext("Message", "AddUserFailed")
                        .Error($"Failed: {result} StatusCode: {490}");
                    return ResultStatusType.failed;
                }

            }
            catch (Exception)
            {
                Log.ForContext("Message", "AddUserError")
                    .Error($"Error:  StatusCode: {491}");
                return ResultStatusType.failed;
            }
        }
    }
}