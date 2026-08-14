using Application.Interface;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MagiaRepository : IMagiaRepository
    {
        private readonly AppDbContext _context;

        public MagiaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Magia>> ObterTodasAsync()
        {
            return await _context.Magias
                .Include(m => m.Classes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Magia?> ObterPorIdAsync(int id)
        {
            return await _context.Magias
                .Include(m => m.Classes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AdicionarAsync(Magia magia)
        {
            await _context.Magias.AddAsync(magia);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Magia magia)
        {
            _context.Magias.Update(magia);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var magia = await _context.Magias.FindAsync(id);
            if (magia != null)
            {
                _context.Magias.Remove(magia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
