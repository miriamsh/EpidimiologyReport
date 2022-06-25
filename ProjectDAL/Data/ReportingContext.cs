using System;
using System.Collections.Generic;
using EpidimiologyReport.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EpidimiologyReport.Dal.Models
{
    public partial class ReportingContext : DbContext
    {
        public ReportingContext()
        {
        }

        public ReportingContext(DbContextOptions<ReportingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //         optionsBuilder.UseSqlServer("Server=LAPTOP-PM9O5HJ5;Database=Reporting;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Location");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Location__Patien__25869641");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
