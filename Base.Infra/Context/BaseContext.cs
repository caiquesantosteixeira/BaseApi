using System;
using Base.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace Base.Infra.Context
{
    public partial class BaseContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
                   = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Deposito> Depositos { get; set; }
        public virtual DbSet<Saque> Saques { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("saldo");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.ToTable("deposito");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.NomeRemetente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeRemetente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Depositos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__deposito__nomeRe__34C8D9D1");
            });

            modelBuilder.Entity<Saque>(entity =>
            {
                entity.ToTable("saque");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Saques)
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
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdClienteDestinatarioNavigation)
                    .WithMany(p => p.TransferenciumIdClienteDestinatarioNavigations)
                    .HasForeignKey(d => d.IdClienteDestinatario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transfere__idCli__38996AB5");

                entity.HasOne(d => d.IdClienteRemetenteNavigation)
                    .WithMany(p => p.TransferenciumIdClienteRemetenteNavigations)
                    .HasForeignKey(d => d.IdClienteRemetente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__transfere__idCli__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
