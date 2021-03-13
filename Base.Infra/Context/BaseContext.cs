using System;
using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Base.Infra.Context.BaseContext
{
    public partial class BaseContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Deposito> Deposito { get; set; }
        public virtual DbSet<Saque> Saque { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OKMI7T9;Initial Catalog=base;User Id=sa;Password=8246kaka!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.ToTable("deposito");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10, 2)");
                entity.Property(e => e.NomeRemetente)
                    .HasColumnName("nomeRemetente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnName("Data");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Deposito)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__deposito__nomeRe__34C8D9D1");
            });

            modelBuilder.Entity<Saque>(entity =>
            {
                entity.ToTable("saque");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Valor)
                        .HasColumnName("valor")
                        .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Data).HasColumnName("Data");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Saque)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__saque__idCliente__31EC6D26");
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.ToTable("transferencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdClienteDestinatario).HasColumnName("idClienteDestinatario");

                entity.Property(e => e.IdClienteRemetente).HasColumnName("idClienteRemetente");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Data).HasColumnName("Data");

                entity.HasOne(d => d.IdClienteDestinatarioNavigation)
                    .WithMany(p => p.TransferenciaIdClienteDestinatarioNavigation)
                    .HasForeignKey(d => d.IdClienteDestinatario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transfere__idCli__3C69FB99");

                entity.HasOne(d => d.IdClienteRemetenteNavigation)
                    .WithMany(p => p.TransferenciaIdClienteRemetenteNavigation)
                    .HasForeignKey(d => d.IdClienteRemetente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transfere__idCli__3B75D760");
            });
        }
    }
}
