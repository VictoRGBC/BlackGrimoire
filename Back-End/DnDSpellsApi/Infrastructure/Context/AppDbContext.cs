using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        // DbSet para as entidades
        public DbSet<Magia> Magias { get; set; }
        public DbSet<Classe> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração explícita da relação N:M refletindo o diagrama
            modelBuilder.Entity<Magia>()
                .HasMany(m => m.Classes)
                .WithMany(c => c.Magias)
                .UsingEntity(j => j.ToTable("Magia_Classes")); // Nomeia a tabela associativa
        }
    }
}