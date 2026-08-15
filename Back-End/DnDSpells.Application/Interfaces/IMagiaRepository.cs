using DnDSpells.Domain.Entities;

namespace DnDSpells.Application.Interfaces;

public interface IMagiaRepository
{
    Task<IEnumerable<Magia>> GetAllAsync();
    Task<Magia?> GetByIdAsync(int id);
    Task<Magia> AddAsync(Magia magia);
    Task UpdateAsync(Magia magia);
    Task DeleteAsync(int id);
}