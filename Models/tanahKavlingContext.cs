using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_097_C.Models
{
    public partial class tanahKavlingContext : DbContext
    {
        public tanahKavlingContext()
        {
        }

        public tanahKavlingContext(DbContextOptions<tanahKavlingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginAdmin> LoginAdmins { get; set; }
        public virtual DbSet<Pembeli> Pembelis { get; set; }
        public virtual DbSet<Penjual> Penjuals { get; set; }
        public virtual DbSet<Tanah> Tanahs { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LoginAdmin>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("Login_Admin");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("Pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pembeli");

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_Transaksi");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Pembeli");

                entity.Property(e => e.NoHpPembeli)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("NoHP_Pembeli");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithMany(p => p.Pembelis)
                    .HasForeignKey(d => d.IdTransaksi)
                    .HasConstraintName("FK_Pembeli_Transaksi");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.ToTable("Penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Penjual");

                entity.Property(e => e.AlamatPenjual)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Penjual");

                entity.Property(e => e.EmailPenjual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email_Penjual");

                entity.Property(e => e.IdTanah).HasColumnName("ID_Tanah");

                entity.Property(e => e.NamaPenjual)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Penjual");

                entity.Property(e => e.NoHpPenjual)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("NoHp_Penjual");

                entity.Property(e => e.TentangPenjual)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Tentang_Penjual");

                entity.HasOne(d => d.IdTanahNavigation)
                    .WithMany(p => p.Penjuals)
                    .HasForeignKey(d => d.IdTanah)
                    .HasConstraintName("FK_Penjual_Tanah");
            });

            modelBuilder.Entity<Tanah>(entity =>
            {
                entity.HasKey(e => e.IdTanah);

                entity.ToTable("Tanah");

                entity.Property(e => e.IdTanah)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Tanah");

                entity.Property(e => e.AlamatTanah)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Alamat_Tanah");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.JudulTanah)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Judul_Tanah");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdTanah).HasColumnName("ID_Tanah");

                entity.Property(e => e.Tanggal).HasColumnType("date");

                entity.HasOne(d => d.IdTanahNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdTanah)
                    .HasConstraintName("FK_Transaksi_Tanah");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
