using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripsFinder.DAL.Models;
using TripsFinder.DAL.Models.Identity;
using TripsFinder.DAL.ModelsConfigs;

namespace TripsFinder.DAL.Context
{
    public class TripsFinderContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public TripsFinderContext(DbContextOptions<TripsFinderContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {  
            // add configurations of models
            builder.ApplyConfiguration(new CheckPointConfig());
            builder.ApplyConfiguration(new CheckPointFileConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new TripConfig());
            builder.ApplyConfiguration(new MediaFileConfig());
            builder.ApplyConfiguration(new TripUserConfig());

            builder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            builder.Entity<UserRole>(entity => { entity.HasKey(e => new {e.UserId, e.RoleId}); });

            builder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            // config another table names to identity classes
            builder.Entity<User>()
                .ToTable("Users");

            builder.Entity<Role>()
                .ToTable("Roles");

            builder.Entity<UserRole>()
                .ToTable("UserRoles");

            builder.Entity<UserToken>()
                .ToTable("UserTokens");

            builder.Entity<UserLogin>()
                .ToTable("UserLogins");

            builder.Entity<UserClaim>()
                .ToTable("UserClaims");

            builder.Entity<RoleClaim>()
                .ToTable("RoleClaims");

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
