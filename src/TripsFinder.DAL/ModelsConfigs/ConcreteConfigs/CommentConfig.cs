using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.DAL.Models;
using TripsFinder.DAL.Models.Concrete;

namespace TripsFinder.DAL.ModelsConfigs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Dislikes).HasDefaultValueSql("((0))");

            builder.Property(e => e.Likes).HasDefaultValueSql("((0))");

            builder.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(d => d.Trip)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Trips");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users");
        }
    }
}
