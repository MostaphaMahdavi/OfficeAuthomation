using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Enums;

namespace OfficeAuthomation.Servicess.Accounts.Users.Commands.Behaviors
{
   public class AddUserValid<TRequest, TResponse> : IPipelineBehavior<AddUserCommand, ResultStatusType>
    {
        public async Task<ResultStatusType> Handle(AddUserCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<ResultStatusType> next)
        {
            if(request.FirstName==null)
                throw new Exception("Not Valid");
            if (request.LastName==null)
                throw new Exception("Not Valid");
            if (request.Address == null)
                throw new Exception("Not Valid");
            if (request.Email == null)
                throw new Exception("Not Valid");
            if (request.ImagePath == null)
                throw new Exception("Not Valid");
            if (request.SignaturePath == null)
                throw new Exception("Not Valid");
            if (request.MeliCode == null)
                throw new Exception("Not Valid");
            if (request.PhoneNumber == null)
                throw new Exception("Not Valid");
            if (request.PersonalCode == null)
                throw new Exception("Not Valid");
            if (request.ShamsiBirthDate == null)
                throw new Exception("Not Valid");
            if (request.UserName == null)
                throw new Exception("Not Valid");
            //if (request.Gender !=1 || request.Gender!=2)
            //    throw new Exception("Not Valid");
            //if (request.RoleUser !=1 || request.RoleUser!=2)
            //    throw new Exception("Not Valid");



            return await next();
           
        }
    }
}
