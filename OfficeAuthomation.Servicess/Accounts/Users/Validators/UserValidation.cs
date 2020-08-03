using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using OfficeAuthomation.Domains.Accounts.Users.Entities;

namespace OfficeAuthomation.Servicess.Accounts.Users.Validators
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر 150 کاراکتر می باشد.")
                .WithName("نام");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر 150 کاراکتر می باشد.")
                .WithName("نام خانوادگی");


            RuleFor(u => u.Address).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .MaximumLength(1000).WithMessage("{PropertyName} حداکثر 1000 کاراکتر می باشد.")
                .WithName("آدرس");


            RuleFor(u => u.ShamsiBirthDate).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .MaximumLength(10).WithMessage("{PropertyName} حداکثر 10 کاراکتر می باشد.")
                .WithName("تاریخ تولد");

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .WithName("جنسیت");

            RuleFor(u => u.MeliCode).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .MaximumLength(10).WithMessage("{PropertyName} حداکثر 10 کاراکتر می باشد.")
                .WithName("کد ملی");

            RuleFor(u => u.PersonalCode).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .MaximumLength(10).WithMessage("{PropertyName} حداکثر 10 کاراکتر می باشد.")
                .WithName("کد پرسنلی");

            RuleFor(u => u.ImagePath).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .WithName("تصویر کاربر");

            RuleFor(u => u.SignaturePath).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشذ.")
                .WithName("امضا کاربر");





        }
    }
}
