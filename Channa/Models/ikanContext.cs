using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Channa.Models
{
    public partial class ikanContext : DbContext
    {
        public ikanContext()
        {
        }

        public ikanContext(DbContextOptions<ikanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ikan> Ikan { get; set; }
        public virtual DbSet<Pembayaran> Pembayaran { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Penjual> Penjual { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ikan>(entity =>
            {
                entity.HasKey(e => e.IdIkan);

                entity.ToTable("ikan");

                entity.Property(e => e.IdIkan)
                    .HasColumnName("ID_ikan")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaIkan).HasColumnName("harga_ikan");

                entity.Property(e => e.NamaIkan)
                    .HasColumnName("nama_ikan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StockIkan).HasColumnName("stock_ikan");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.ToTable("pembayaran");

                entity.Property(e => e.IdPembayaran)
                    .HasColumnName("ID_pembayaran")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPenjual).HasColumnName("ID_penjual");

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_transaksi");

                entity.Property(e => e.TanggalPembayaran)
                    .HasColumnName("tanggal_pembayaran")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalPembayaran).HasColumnName("total_pembayaran");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("pembeli");

                entity.Property(e => e.IdPembeli)
                    .HasColumnName("ID_pembeli")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_Hp")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.ToTable("penjual");

                entity.Property(e => e.IdPenjual)
                    .HasColumnName("ID_penjual")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("No_Hp")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("transaksi");

                entity.Property(e => e.IdTransaksi)
                    .HasColumnName("ID_transaksi")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdIkan).HasColumnName("ID_ikan");

                entity.Property(e => e.IdPembeli).HasColumnName("ID_pembeli");

                entity.Property(e => e.JumlahTransaksi).HasColumnName("jumlah_transaksi");

                entity.Property(e => e.TanggalTransaksi)
                    .HasColumnName("tanggal_transaksi")
                    .HasColumnType("datetime");
            });
        }
    }
}
