using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.DAL.Models;
using TripsFinder.DAL.Models.Concrete;

namespace TripsFinder.DAL.ModelsConfigs
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasIndex(e => e.StartingPointId)
                .HasName("UQ__Trips__17FA1EACAB460CFF")
                .IsUnique();

            builder.Property(e => e.Description).HasMaxLength(256);

            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.Property(e => e.StartDate).HasColumnType("date");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(d => d.ArrivalPoint)
                .WithMany(p => p.TripsArrivalPoint)
                .HasForeignKey(d => d.ArrivalPointId)
                .HasConstraintName("FK_TripsEnd_CheckPoints");

            builder.HasOne(d => d.CreatedByUser)
                .WithMany(p => p.Trips)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trips_Users");

            builder.HasOne(d => d.PosterImage)
                .WithMany(p => p.Trips)
                .HasForeignKey(d => d.PosterImageId)
                .HasConstraintName("FK_Trips_MediaFiles");

            builder.HasOne(d => d.StartingPoint)
                .WithOne(p => p.TripStartingPoint)
                .HasForeignKey<Trip>(d => d.StartingPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TripsStart_CheckPoints");
        }
    }
}
