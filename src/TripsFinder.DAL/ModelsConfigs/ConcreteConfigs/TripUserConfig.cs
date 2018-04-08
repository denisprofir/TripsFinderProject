using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.DAL.Models;
using TripsFinder.DAL.Models.Concrete;

namespace TripsFinder.DAL.ModelsConfigs
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
