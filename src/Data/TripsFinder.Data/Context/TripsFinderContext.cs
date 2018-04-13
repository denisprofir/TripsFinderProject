using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripsFinder.Data.Domain.DomainModels.Identity;
using TripsFinder.Data.Domain.DomainModelsConfigs.ConcreteConfigs;
using TripsFinder.Data.Domain.DomainModelsConfigs.IdentityConfigs;

namespace TripsFinder.Data.Context
{
    public class TripsFinderContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public TripsFinderContext(DbContextOptions<TripsFinderContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {  
            // add configurations of concrete models
            builder.ApplyConfiguration(new CheckPointConfig());
            builder.ApplyConfiguration(new CheckPointFileConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new TripConfig());
            builder.ApplyConfiguration(new MediaFileConfig());
            builder.ApplyConfiguration(new TripUserConfig());
            

            // add configurations of identity classes
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleClaimConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new UserClaimConfig());
            builder.ApplyConfiguration(new UserLoginConfig());
            builder.ApplyConfiguration(new UserRoleConfig());
            builder.ApplyConfiguration(new UserTokenConfig());

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
