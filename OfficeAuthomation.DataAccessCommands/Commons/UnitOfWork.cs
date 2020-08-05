using Microsoft.AspNetCore.Identity;
using OfficeAuthomation.DataAccessCommands.Accounts.Users.Repositories;
using OfficeAuthomation.DataAccessCommands.Context;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using OfficeAuthomation.Domains.Commons;
using System.Threading.Tasks;

namespace OfficeAuthomation.DataAccessCommands.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OfficeAuthomationContext _db;

        public UnitOfWork(OfficeAuthomationContext db)
        {
            _db = db;
        }



      


        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}