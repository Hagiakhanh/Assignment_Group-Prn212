using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AssignmentGroup_Repository.Models;

public partial class CarDbSetContext : DbContext
{
    public CarDbSetContext()
    {
    }

    public CarDbSetContext(DbContextOptions<CarDbSetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<FuelType> FuelTypes { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<SellerType> SellerTypes { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string ConnectionStr = config.GetConnectionString("DefaultConnectionStringDB");

            optionsBuilder.UseSqlServer(ConnectionStr);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars__68A0340E7DA5FD60");

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.FuelTypeId).HasColumnName("FuelTypeID");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.PresentPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SellerTypeId).HasColumnName("SellerTypeID");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TransmissionId).HasColumnName("TransmissionID");

            entity.HasOne(d => d.FuelType).WithMany(p => p.Cars)
                .HasForeignKey(d => d.FuelTypeId)
                .HasConstraintName("FK__Cars__FuelTypeID__3F466844");

            entity.HasOne(d => d.Owner).WithMany(p => p.Cars)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Cars__OwnerID__4222D4EF");

            entity.HasOne(d => d.SellerType).WithMany(p => p.Cars)
                .HasForeignKey(d => d.SellerTypeId)
                .HasConstraintName("FK__Cars__SellerType__403A8C7D");

            entity.HasOne(d => d.Transmission).WithMany(p => p.Cars)
                .HasForeignKey(d => d.TransmissionId)
                .HasConstraintName("FK__Cars__Transmissi__412EB0B6");
        });

        modelBuilder.Entity<FuelType>(entity =>
        {
            entity.HasKey(e => e.FuelTypeId).HasName("PK__FuelType__048BEE578E523749");

            entity.Property(e => e.FuelTypeId).HasColumnName("FuelTypeID");
            entity.Property(e => e.FuelTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Owners__819385985DCB5514");

            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.OwnerType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SellerType>(entity =>
        {
            entity.HasKey(e => e.SellerTypeId).HasName("PK__SellerTy__53553107A0674004");

            entity.Property(e => e.SellerTypeId).HasColumnName("SellerTypeID");
            entity.Property(e => e.SellerTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.HasKey(e => e.TransmissionId).HasName("PK__Transmis__56E90A6EC4373568");

            entity.Property(e => e.TransmissionId).HasColumnName("TransmissionID");
            entity.Property(e => e.TransmissionType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
