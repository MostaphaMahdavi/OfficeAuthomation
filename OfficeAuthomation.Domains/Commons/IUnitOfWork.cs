using System;
using System.Threading.Tasks;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;

namespace OfficeAuthomation.Domains.Commons
{
    public interface IUnitOfWork:IDisposable
    {

       


        Task Save();
    }
}