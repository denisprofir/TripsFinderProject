using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.Data.Domain.DomainModels.Concrete;

namespace TripsFinder.Data.Domain.DomainModelsConfigs.ConcreteConfigs
{
    public class TripUserConfig : IEntityTypeConfiguration<TripUser>
    {
        public void Configure(EntityTypeBuilder<TripUser> builder)
        {
            builder.HasKey(e => new { e.TripId, e.UserId });

            builder.HasOne(d => d.Trip)
                .WithMany(p => p.TripUsers)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TripUsers_Trips");

            builder.HasOne(d => d.User)
                .WithMany(p => p.TripUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TripUsers_Users");
        }
    }
}
