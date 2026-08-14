using Application.Interface;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        private readonly AppDbContext _context;

        public ClasseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Classe>> ObterTodasAsync()
        {
            return await _context.Classes
                .Include(c => c.Magias)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Classe?> ObterPorIdAsync(int id)
        {
            return await _context.Classes
                .Include(c => c.Magias)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AdicionarAsync(Classe classe)
        {
            await _context.Classes.AddAsync(classe);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Classe classe)
        {
            _context.Classes.Update(classe);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var classe = await _context.Classes.FindAsync(id);
            if (classe != null)
            {
                _context.Classes.Remove(classe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
