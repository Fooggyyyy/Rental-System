using System;
using Rental;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rental
{
    public class Config : DbContext
    {
        private string? ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=RentalSystem;Trusted_Connection=True;";

        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<PropertyDetails> PropertiesDetails => Set<PropertyDetails>();
        public DbSet<LeaseAgreement> LeaseAgreements => Set<LeaseAgreement>();
        public DbSet<Payment> Payments => Set<Payment>();

        public Config(string? ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=RentalSystem;Trusted_Connection=True;")
        {
            Database.EnsureCreated();
            this.ConnectionString = ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OwnersConfig());
            modelBuilder.ApplyConfiguration(new TenantsConfig());
            modelBuilder.ApplyConfiguration(new PropertiesConfig());
            modelBuilder.ApplyConfiguration(new PropertyDetailsConfig());
            modelBuilder.ApplyConfiguration(new LeaseAgreementsConfig());
            modelBuilder.ApplyConfiguration(new PaymentsConfig());
        }
    }

    public class OwnersConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> model)
        {
            model.ToTable("Owners");

            model.HasKey(o => o.IdGET);

            model.Property(o => o.NameGET)
                .IsRequired()
                .HasMaxLength(100);

            model.Property(o => o.EmailGET)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            model.HasIndex(o => o.EmailGET).IsUnique();

            model.Property(o => o.PhoneNumberGET)
                .HasMaxLength(15);

            model.HasMany(o => o.PaymentListGET)
                .WithOne()
                .HasForeignKey(p => p.Owner_IdGET)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TenantsConfig : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> model)
        {
            model.ToTable("Tenants");

            model.HasKey(t => t.IdGET);

            model.Property(t => t.NameGET)
                .IsRequired()
                .HasMaxLength(100);

            model.Property(t => t.EmailGET)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            model.HasIndex(t => t.EmailGET).IsUnique();

            model.Property(t => t.PhoneNumberGET)
                .HasMaxLength(15);

            model.HasMany(t => t.LeaseAgreementsListGET)
                .WithOne()
                .HasForeignKey(l => l.TenantGET)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PropertiesConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> model)
        {
            model.ToTable("Properties");

            model.HasKey(p => p.IdGET);

            model.Property(p => p.AddresGET)
                .IsRequired()
                .HasMaxLength(200);

            model.Property(p => p.TypeGET)
                .IsRequired();

            model.Property(p => p.CostGET)
                .IsRequired();

            model.Property(p => p.AreaGET)
                .IsRequired();

            model.HasOne<Owner>()
                .WithMany(o => o.PaymentListGET)
                .HasForeignKey(p => p.Owner_IdGET)
                .OnDelete(DeleteBehavior.Cascade);

            model.HasOne(p => p.DetailsGET)
                .WithOne()
                .HasForeignKey<PropertyDetails>(d => d.Property_IdGET)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


    public class PropertyDetailsConfig : IEntityTypeConfiguration<PropertyDetails>
    {
        public void Configure(EntityTypeBuilder<PropertyDetails> model)
        {
            model.ToTable("PropertyDetails");

            model.HasKey(pd => pd.IdGET); 

            model.Property(pd => pd.RoomsGET)
                .IsRequired();

            model.Property(pd => pd.FlatGET)
                .IsRequired();

            model.Property(pd => pd.BuildYearsGET)
                .IsRequired();

            model.Property(pd => pd.Property_IdGET)
                .IsRequired();

            // Связь с Property
            model.HasOne<Property>()
                .WithOne(p => p.DetailsGET)
                .HasForeignKey<PropertyDetails>(pd => pd.Property_IdGET)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }



    public class LeaseAgreementsConfig : IEntityTypeConfiguration<LeaseAgreement>
    {
        public void Configure(EntityTypeBuilder<LeaseAgreement> model)
        {
            model.ToTable("LeaseAgreements");

            model.HasKey(l => l.IdGET);

            model.Property(l => l.DateStartGET)
                .IsRequired();

            model.Property(l => l.DateEndGET)
                .IsRequired();

            model.Property(l => l.CostGET)
                .IsRequired();

            model.HasOne<Tenant>()
                .WithMany(t => t.LeaseAgreementsListGET)
                .HasForeignKey(l => l.TenantGET)
                .OnDelete(DeleteBehavior.Cascade);

            model.HasOne<Property>()
                .WithMany(p => p.LeaseAgreementListGET)
                .HasForeignKey(l => l.PropertyGET)
                .OnDelete(DeleteBehavior.Cascade);

            model.HasOne(l => l.PaymentGET)
                .WithOne()
                .HasForeignKey<Payment>(p => p.LeaseAgreement_IdGET);
        }
    }


    public class PaymentsConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> model)
        {
            model.ToTable("Payments");

            model.HasKey(p => p.IdGET);

            model.Property(p => p.CostGET).IsRequired();

            model.Property(p => p.DatePaymentGET).IsRequired();

            model.Property(p => p.TypePaymentGET).IsRequired();

            model.HasOne<LeaseAgreement>()
                .WithOne(l => l.PaymentGET)
                .HasForeignKey<Payment>(p => p.LeaseAgreement_IdGET)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
