using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeAuthomation.Domains.Accounts.Roles.Entities;

namespace OfficeAuthomation.DataAccessCommands.Accounts.Roles.Configs
{
    public class RoleConfig:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
        }
    }
}