using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace OfficeAuthomation.Domains.Accounts.Users.Entities
{
    public class User : IdentityUser
    {

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }
        public string ShamsiBirthDate { get; set; }
        public byte Gender { get; set; }
        public byte RoleAdmin { get; set; }
        public bool IsActive { get; set; }

        public string MeliCode { get; set; }
        public string PersonalCode { get; set; }

        public string ImagePath { get; set; }

        public string SignaturePath { get; set; }

        public DateTime RegisterDate { get; set; }


        #endregion


    }
}
