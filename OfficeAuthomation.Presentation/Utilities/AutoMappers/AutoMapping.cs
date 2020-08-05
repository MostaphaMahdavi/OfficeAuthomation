using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Presentation.Accounts;

namespace OfficeAuthomation.Presentation.Utilities.AutoMappers
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<EditUserCommand, UserViewModel>().ReverseMap();
        }
    }
}
