using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", SchemaNames.Security);
        }
    }

    internal class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", SchemaNames.Security);
        }
    }

    internal class IdentityRoleClaimConfig : IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
        {
            builder.ToTable("RoleClaims", SchemaNames.Security);
        }
    }

    internal class IdentityUserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {
            builder.ToTable("UserClaims", SchemaNames.Security);
        }
    }

    internal class IdentityUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            builder
                .ToTable("UserTokens", SchemaNames.Security);

        }
    }

    internal class IdentityUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
        {
            builder
                .ToTable("UserLogins", SchemaNames.Security);

        }
    }

    internal class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder
                .ToTable("UserRoles", SchemaNames.Security);

        }
    }
}
