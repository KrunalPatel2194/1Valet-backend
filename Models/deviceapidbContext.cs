using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class deviceapidbContext : DbContext
    {
        public deviceapidbContext()
        {
        }

        public deviceapidbContext(DbContextOptions<deviceapidbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<DeviceType> DeviceTypes { get; set; } = null!;
        public virtual DbSet<DeviceUsage> DeviceUsages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-A46VD52\\SQLEXPRESS;Database=deviceapidb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceId).ValueGeneratedNever();

                entity.Property(e => e.DeviceImage).HasMaxLength(200);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .HasConstraintName("FK_Devices_DeviceType");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("DeviceType");

                entity.Property(e => e.DeviceTypeId).ValueGeneratedNever();

                entity.Property(e => e.DeviceType1)
                    .HasMaxLength(50)
                    .HasColumnName("DeviceType");
            });

            modelBuilder.Entity<DeviceUsage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DeviceUsage");

                entity.Property(e => e.DeviceUsageFromDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceUsageToDateTime)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
