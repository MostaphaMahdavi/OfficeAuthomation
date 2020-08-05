using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using OfficeAuthomation.Domains.Enums;

namespace OfficeAuthomation.Domains.Accounts.Users.Commands
{
   public class ActiveOrDeactiveUserInfo:IRequest<ResultStatusType>
    {
        public string UserId { get; set; }

        public ActiveOrDeactiveUserInfo(string userId)
        {
            UserId = userId;
        }
    }
}
