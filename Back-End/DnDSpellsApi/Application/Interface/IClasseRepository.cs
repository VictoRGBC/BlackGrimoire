using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IClasseRepository
    {
        Task<IEnumerable<Classe>> ObterTodasAsync();
        Task<Classe?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Classe classe);
        Task DeletarAsync(int id);
    }
}
