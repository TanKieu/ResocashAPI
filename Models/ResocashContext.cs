using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ResocashAPI.Models
{
    public partial class ResocashContext : DbContext
    {
        public ResocashContext()
        {
        }

        public ResocashContext(DbContextOptions<ResocashContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CashTransaction> CashTransactions { get; set; }
        public virtual DbSet<Casher> Cashers { get; set; }
        public virtual DbSet<CashingRequest> CashingRequests { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Prefer> Prefers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=swd-resocash.database.windows.net;Initial Catalog=Resocash;User ID=toor;Password=BA5EYcmcnLVrrZGrKparD2NYc");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.CasherId).IsUnicode(false);

                entity.Property(e => e.StoreId).IsUnicode(false);

                entity.HasOne(d => d.Casher)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CasherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Casher1");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Store1");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.BrandAccount).IsUnicode(false);

                entity.Property(e => e.BrandAddress).IsUnicode(false);

                entity.Property(e => e.BrandName).IsUnicode(false);

                entity.Property(e => e.BrandPhone).IsUnicode(false);
            });

            modelBuilder.Entity<CashTransaction>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.BrandId).IsUnicode(false);

                entity.Property(e => e.CasherId).IsUnicode(false);

                entity.Property(e => e.StoreId).IsUnicode(false);

                entity.Property(e => e.TransactionStatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.CashTransactions)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CashTransaction_Brand");
            });

            modelBuilder.Entity<Casher>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WalletId).IsUnicode(false);
            });

            modelBuilder.Entity<CashingRequest>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.CasherId).IsUnicode(false);

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.Property(e => e.StoreId).IsUnicode(false);

                entity.HasOne(d => d.Casher)
                    .WithMany(p => p.CashingRequests)
                    .HasForeignKey(d => d.CasherId)
                    .HasConstraintName("FK_CashingRequest_Casher");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CashingRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CashingRequest_Employee");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CashingRequests)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_CashingRequest_Store");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.EmployeePhone).IsUnicode(false);

                entity.Property(e => e.EmployeeSex).IsUnicode(false);

                entity.Property(e => e.StoreId).IsUnicode(false);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Employee_Store");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.AreaId).IsUnicode(false);

                entity.Property(e => e.CasherId).IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Area");

                entity.HasOne(d => d.Casher)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CasherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Casher");
            });

            modelBuilder.Entity<Prefer>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.BrandId).IsUnicode(false);

                entity.Property(e => e.CasherId).IsUnicode(false);

                entity.HasOne(d => d.Casher)
                    .WithMany(p => p.Prefers)
                    .HasForeignKey(d => d.CasherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prefer_Casher");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.AreaId).IsUnicode(false);

                entity.Property(e => e.BrandId).IsUnicode(false);

                entity.Property(e => e.StorePhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Store_Area");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Store_Brand");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.CasherId).IsUnicode(false);

                entity.Property(e => e.WalletStatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Casher)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.CasherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wallet_Casher");
            });

            modelBuilder.Entity<WalletTransaction>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.WalletId).IsUnicode(false);

                entity.HasOne(d => d.Wallet)
                    .WithMany()
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK_WalletTransaction_Wallet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
