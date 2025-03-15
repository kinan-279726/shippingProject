using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domains;
using System.Reflection.Emit;

namespace DataAccess;
public class DbContextShipment : IdentityDbContext<TbUsers> // inhiret from custom users class to add my column 
{
    public DbContextShipment()
    {
    }

    public DbContextShipment(DbContextOptions<DbContextShipment> options) : base(options)
    {
    }
    // tables
    public virtual DbSet<TbCarriers> TbCarriers { get; set; }
    public virtual DbSet<TbAboutUs> TbAboutUs { get; set; }
    public virtual DbSet<TbCities> TbCities { get; set; }
    public virtual DbSet<TbCountries> TbCountries { get; set; }
    public virtual DbSet<TbHomeSliders> TbHomeSliders { get; set; }
    public virtual DbSet<TbPaymentMethod> TbPaymentMethod { get; set; }
    public virtual DbSet<TbSettings> TbSettings { get; set; }
    public virtual DbSet<TbShipments> TbShipments { get; set; }
    public virtual DbSet<TbShipmentStatus> TbShipmentStatus { get; set; }
    public virtual DbSet<TbShipmentType> TbShipmentType { get; set; }
    public virtual DbSet<TbSubscriptionPackages> TbSubscriptionPackages { get; set; }
    public virtual DbSet<TbUsersReceivers> TbUsersReceivers { get; set; }
    public virtual DbSet<TbUsersSender> TbUsersSender { get; set; }
    public virtual DbSet<TbUserSubscriptions> TbUserSubscriptions { get; set; }

    // views
    public virtual DbSet<VwCiti> VwCitis { get; set; }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TbUsersReceivers>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.tbUsers)
            .WithOne(b => b.tbUsersReceivers)
            .HasForeignKey<TbUsersReceivers>(a => a.UserId);

            entity.HasOne(a => a.tbCities)
            .WithMany(a => a.Receivers)
            .HasForeignKey(a => a.CityId);
        });

        builder.Entity<TbUserSubscriptions>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.tbUsers)
            .WithMany(a => a.Subscriptions)
            .HasForeignKey(a => a.UserId);

            entity.HasOne(a => a.tbSubscriptionsPackages)
            .WithMany(b => b.Subscriptions)
            .HasForeignKey(a => a.PackageId);
        });

        builder.Entity<TbUsersSender>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.tbUsers)
            .WithOne(a => a.tbUsersSender)
            .HasForeignKey<TbUsersSender>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.tbCities)
            .WithMany(a => a.Senders).HasForeignKey(a => a.CityId).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<TbSubscriptionPackages>(entity =>
        {
            entity.HasKey(a => a.Id);
        });

        builder.Entity<TbShipmentType>(entity =>
        {
            entity.HasKey(a => a.Id);

        });

        builder.Entity<TbShipmentStatus>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.tbShipments)
            .WithOne(a => a.tbShipmentStatus)
            .HasForeignKey<TbShipmentStatus>(a => a.ShipmentId);

            entity.HasOne(a => a.tbCarriers)
            .WithMany(a => a.ShipmentStatus)
            .HasForeignKey(a => a.CarrierId);
        });

        builder.Entity<TbShipments>(static entity =>
        {
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.tbSenders)
            .WithMany(a => a.Shipments)
            .HasForeignKey(a => a.SenderId).OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.tbReceivers)
            .WithMany(a => a.Shipments)
            .HasForeignKey(a => a.ReceiverId).OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.tbShipmentType)
            .WithMany(a => a.Shipments)
            .HasForeignKey(a => a.ShippingTypeId).OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.tbPaymentMethod)
            .WithMany(a => a.Shipments)
            .HasForeignKey(a => a.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.tbUserSubscriptions)
            .WithOne(a => a.tbShipments)
            .HasForeignKey<TbShipments>(a => a.UserSubscriptionId).OnDelete(DeleteBehavior.NoAction);

        });

        builder.Entity<TbPaymentMethod>(entity =>
        {
            entity.HasKey(entity => entity.Id);
        });

        builder.Entity<TbHomeSliders>(entity =>
        {
            entity.HasKey(entity => entity.Id);
        });

        builder.Entity<TbCountries>().HasKey(entity => entity.Id);

        builder.Entity<TbCities>(entity =>
        {
            entity.HasKey(entity => entity.Id);

            entity.HasOne(a => a.Countries)
            .WithMany(a => a.Cities)
            .HasForeignKey(a => a.CountryId);
        });

        builder.Entity<TbCarriers>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.HasOne(a => a.tbUsers)
            .WithOne(a => a.tbCarriers)
            .HasForeignKey<TbCarriers>(a => a.UserId);
        });

        builder.Entity<TbAboutUs>().HasKey(a => a.Id);

        builder.Entity<VwCiti>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwCitis");

            entity.Property(e => e.CityArabicName).HasMaxLength(100);
            entity.Property(e => e.CityEnglithName).HasMaxLength(100);
            entity.Property(e => e.CityId).HasMaxLength(450);
            entity.Property(e => e.CountryArabicName).HasMaxLength(100);
            entity.Property(e => e.CountryEnglishName).HasMaxLength(100);
            entity.Property(e => e.CountryId).HasMaxLength(450);
        });

    }
    protected override Version SchemaVersion => base.SchemaVersion;
}
