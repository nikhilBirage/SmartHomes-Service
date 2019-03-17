using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartHome.API.Models
{
    public partial class SmartHomeContext : DbContext
    {
        public SmartHomeContext()
        {
        }

        public SmartHomeContext(DbContextOptions<SmartHomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MeterReading> MeterReading { get; set; }
        public virtual DbSet<MeterUser> MeterUser { get; set; }
        public virtual DbSet<Recharge> Recharge { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetail { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Data Source=(localdb)\\DBNAME;Initial Catalog=smartHome;Integrated Security=True");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterReading>(entity =>
            {
                entity.ToTable("meterReading");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MeterNumber)
                    .IsRequired()
                    .HasColumnName("meterNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.ReadingVolt)
                    .HasColumnName("readingVolt")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ReadingWatt)
                    .HasColumnName("readingWatt")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.MeterNumberNavigation)
                    .WithMany(p => p.MeterReading)
                    .HasForeignKey(d => d.MeterNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_meterReading_meterUser");
            });

            modelBuilder.Entity<MeterUser>(entity =>
            {
                entity.HasKey(e => e.MeterNumber);

                entity.ToTable("meterUser");

                entity.Property(e => e.MeterNumber)
                    .HasColumnName("meterNumber")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Recharge>(entity =>
            {
                entity.ToTable("recharge");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(8);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.ToTable("transactionDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MeterNumber)
                    .IsRequired()
                    .HasColumnName("meterNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasColumnName("transactionId")
                    .HasMaxLength(100);

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
