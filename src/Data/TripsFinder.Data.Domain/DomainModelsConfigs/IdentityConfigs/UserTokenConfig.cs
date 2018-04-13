using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.Data.Domain.DomainModels.Identity;

namespace TripsFinder.Data.Domain.DomainModelsConfigs.IdentityConfigs
{
    public class UserTokenConfig : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserTokens");

            builder.HasKey(e => new {e.UserId, e.LoginProvider, e.Name});
        }
    }
}
