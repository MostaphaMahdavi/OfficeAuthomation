using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Enums;
using OfficeAuthomation.Servicess.Accounts.Users.Commands.Behaviors;
using OfficeAuthomation.Servicess.Accounts.Users.Validators;
using OfficeAuthomation.Servicess.PipelineBehaviors;

namespace OfficeAuthomation.Presentation.Utilities.Extentions.Validations
{
    public static class ValidationExtention
    {

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ErrorHandlingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<AddUserCommand, ResultStatusType>), typeof(AddUserValid<AddUserCommand, ResultStatusType>));





            services.AddTransient<IValidator<User>,UserValidation>();

            return services;
        }
    }
}