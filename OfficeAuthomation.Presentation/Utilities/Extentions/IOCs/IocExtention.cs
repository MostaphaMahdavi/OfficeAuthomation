using Microsoft.Extensions.DependencyInjection;
using OfficeAuthomation.DataAccessCommands.Accounts.Roles.Repositories;
using OfficeAuthomation.DataAccessCommands.Accounts.Users.Repositories;
using OfficeAuthomation.DataAccessCommands.Commons;
using OfficeAuthomation.DataAccessQueries.Accounts.Roles.Repositories;
using OfficeAuthomation.DataAccessQueries.Accounts.Users.Repositories;
using OfficeAuthomation.Domains.Accounts.Roles.Repositories;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using OfficeAuthomation.Domains.Commons;

namespace OfficeAuthomation.Presentation.Utilities.Extentions.IOCs
{
    public static class IocExtention
    {
        public static IServiceCollection AddIoc(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();




            services.AddScoped<IUserRepositoryCommand, UserRepositoryCommand>();
            services.AddScoped<IUserRepositoryQuery, UserRepositoryQuery>();


            services.AddScoped<IRoleRepositoryCommand, RoleRepositoryCommand>();
            services.AddScoped<IRoleRepositoryQuery, RoleRepositoryQuery>();

            return services;
        }
    }
}