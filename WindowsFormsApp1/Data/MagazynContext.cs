using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WindowsFormsApp1.Models;

#nullable disable

namespace WindowsFormsApp1.Data
{
    public partial class MagazynContext : DbContext
    {
        public MagazynContext()
        {
        }

        public MagazynContext(DbContextOptions<MagazynContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MagazynRecord> MagazynRecords { get; set; }
        public virtual DbSet<TypeOfCar> TypeOfCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Magazyn;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<MagazynRecord>(entity =>
            {
                entity.ToTable("MagazynRecord");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.DataReturned).HasColumnType("datetime");

                entity.Property(e => e.DateRented).HasColumnType("datetime");

                entity.HasOne(d => d.TypeOfCar)
                    .WithMany(p => p.MagazynRecords)
                    .HasForeignKey(d => d.TypeOfCarId)
                    .HasConstraintName("FK_MagazynRecord_TypeOfCar");
            });

            modelBuilder.Entity<TypeOfCar>(entity =>
            {
                entity.ToTable("TypeOfCar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
