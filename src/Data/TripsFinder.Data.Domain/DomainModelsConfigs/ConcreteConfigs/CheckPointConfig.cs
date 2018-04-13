using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.Data.Domain.DomainModels.Concrete;

namespace TripsFinder.Data.Domain.DomainModelsConfigs.ConcreteConfigs
{
    public class CheckPointConfig : IEntityTypeConfiguration<CheckPoint>
    {
        public void Configure(EntityTypeBuilder<CheckPoint> builder)
        {
            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Description).HasMaxLength(256);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(d => d.Trip)
                .WithMany(p => p.CheckPoints)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckPoints_Trips");
        }
    }
}
