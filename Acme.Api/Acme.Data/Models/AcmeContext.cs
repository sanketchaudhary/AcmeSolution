using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Acme.Data.Models
{
    public partial class AcmeContext : DbContext
    {
        public AcmeContext()
        {
        }

        public AcmeContext(DbContextOptions<AcmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<InvestorDetails> InvestorDetails { get; set; }
        public virtual DbSet<Postcodes> Postcodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=Acme;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<InvestorDetails>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Postcode).HasMaxLength(4);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InvestorDetails)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvestorDetails_Country");
            });

            modelBuilder.Entity<Postcodes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bspname)
                    .HasColumnName("BSPname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bspnumber)
                    .HasColumnName("BSPnumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Locality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParcelZone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreSortIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
