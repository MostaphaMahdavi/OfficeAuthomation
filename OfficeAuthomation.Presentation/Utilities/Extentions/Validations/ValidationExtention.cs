using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Servicess.Accounts.Users.Validators;

namespace OfficeAuthomation.Presentation.Utilities.Extentions.Validations
{
    public static class ValidationExtention
    {

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<User>,UserValidation>();

            return services;
        }
    }
}