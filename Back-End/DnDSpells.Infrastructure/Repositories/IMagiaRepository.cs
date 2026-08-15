using DnDSpells.Application.Interfaces;
using DnDSpells.Domain.Entities;
using DnDSpells.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DnDSpells.Infrastructure.Repositories;

public class MagiaRepository : IMagiaRepository
{
    private readonly AppDbContext _context;

    public MagiaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Magia>> GetAllAsync()
    {
        // O AsNoTracking otimiza consultas de leitura, pois o EF não precisa rastrear mudanças nessas entidades
        return await _context.Magias.AsNoTracking().ToListAsync();
    }

    public async Task<Magia?> GetByIdAsync(int id)
    {
        return await _context.Magias.FindAsync(id);
    }

    public async Task<Magia> AddAsync(Magia magia)
    {
        _context.Magias.Add(magia);
        await _context.SaveChangesAsync();
        return magia;
    }

    public async Task UpdateAsync(Magia magia)
    {
        _context.Entry(magia).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var magia = await _context.Magias.FindAsync(id);
        if (magia != null)
        {
            _context.Magias.Remove(magia);
            await _context.SaveChangesAsync();
        }
    }
}