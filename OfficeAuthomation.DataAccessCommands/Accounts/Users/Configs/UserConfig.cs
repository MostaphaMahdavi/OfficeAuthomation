using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeAuthomation.Domains.Accounts.Users.Entities;

namespace OfficeAuthomation.DataAccessCommands.Accounts.Users.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Address).IsRequired().HasMaxLength(1000);
            builder.Property(u => u.ShamsiBirthDate).IsRequired().HasMaxLength(10);
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.RoleAdmin).IsRequired();
            builder.Property(u => u.MeliCode).IsRequired().HasMaxLength(10);
            builder.Property(u => u.PersonalCode).IsRequired().HasMaxLength(10);
            builder.Property(u => u.ImagePath).IsRequired();
            builder.Property(u => u.SignaturePath).IsRequired();



        }
    }
}