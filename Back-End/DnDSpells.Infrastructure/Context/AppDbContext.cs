using DnDSpells.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DnDSpells.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Magia> Magias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapeamento fluente (opcional, mas recomendado)
        modelBuilder.Entity<Magia>().HasKey(m => m.Id);
        modelBuilder.Entity<Magia>().Property(m => m.Nome).IsRequired().HasMaxLength(100);
        // O relacionamento (1,n) será configurado aqui posteriormente
    }
}