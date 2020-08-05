using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using OfficeAuthomation.Domains.Enums;

namespace OfficeAuthomation.Domains.Accounts.Users.Commands
{
   public class EditUserCommand:IRequest<ResultStatusType>
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalCode { get; set; }

        public string MeliCode { get; set; }

        public string Address { get; set; }

        public string ShamsiBirthDate { get; set; }

        public byte Gender { get; set; }

        public string ImagePath { get; set; }

        public string SignaturePath { get; set; }

        public byte IsActive { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public byte RoleAdmin { get; set; }

    }
}
