using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WindowsFormsApp1.Models;

#nullable disable

namespace WindowsFormsApp1.Data
{
    public partial class SimpleWarehousContext : DbContext
    {
        public SimpleWarehousContext()
        {
        }

        public SimpleWarehousContext(DbContextOptions<SimpleWarehousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adre> Adres { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleWarehous;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Adre>(entity =>
            {
                entity.HasKey(e => e.IdAdres);

                entity.ToTable("ADRES");

                entity.Property(e => e.IdAdres)
                    .ValueGeneratedNever()
                    .HasColumnName("id_adres");

                entity.Property(e => e.Local)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("local");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("town");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("CATEGORY");

                entity.Property(e => e.IdCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdCompany);

                entity.ToTable("COMPANY");

                entity.Property(e => e.IdCompany)
                    .ValueGeneratedNever()
                    .HasColumnName("id_company");

                entity.Property(e => e.CompanAdres).HasColumnName("compan_adres");

                entity.Property(e => e.CompanyNape)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company_nape");

                entity.Property(e => e.Nip)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("nip");

                entity.HasOne(d => d.CompanAdresNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CompanAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANY_ADRES");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.IdItem);

                entity.ToTable("ITEMS");

                entity.Property(e => e.IdItem)
                    .ValueGeneratedNever()
                    .HasColumnName("id_item");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Depth).HasColumnName("depth");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEMS_CATEGORY");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK_ITEMS_WAREHOUSE");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.ToTable("ORDER");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order");

                entity.Property(e => e.From).HasColumnName("from");

                entity.Property(e => e.OrderItem).HasColumnName("order_item");

                entity.Property(e => e.Purchaser).HasColumnName("purchaser");

                entity.Property(e => e.Sender).HasColumnName("sender");

                entity.Property(e => e.To).HasColumnName("to");

                entity.HasOne(d => d.FromNavigation)
                    .WithMany(p => p.OrderFromNavigations)
                    .HasForeignKey(d => d.From)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ADRES");

                entity.HasOne(d => d.OrderItemNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ITEMS");

                entity.HasOne(d => d.PurchaserNavigation)
                    .WithMany(p => p.OrderPurchaserNavigations)
                    .HasForeignKey(d => d.Purchaser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_PEOPLE1");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.OrderSenderNavigations)
                    .HasForeignKey(d => d.Sender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_PEOPLE");

                entity.HasOne(d => d.ToNavigation)
                    .WithMany(p => p.OrderToNavigations)
                    .HasForeignKey(d => d.To)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ADRES1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPeople);

                entity.ToTable("PEOPLE");

                entity.Property(e => e.IdPeople)
                    .ValueGeneratedNever()
                    .HasColumnName("id_people");

                entity.Property(e => e.Job).HasColumnName("job");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("pesel");

                entity.Property(e => e.Surename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surename");

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.Job)
                    .HasConstraintName("FK_PEOPLE_COMPANY");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.IdWarehouse);

                entity.ToTable("WAREHOUSE");

                entity.Property(e => e.IdWarehouse)
                    .ValueGeneratedNever()
                    .HasColumnName("id_warehouse");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.WarehouseAdres).HasColumnName("warehouse_adres");

                entity.Property(e => e.WarehouseName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("warehouse_name");

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.Company)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WAREHOUSE_COMPANY");

                entity.HasOne(d => d.WarehouseAdresNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.WarehouseAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WAREHOUSE_ADRES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
