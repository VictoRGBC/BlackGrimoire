using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IMagiaRepository
    {
        Task<IEnumerable<Magia>> ObterTodasAsync();
        Task<Magia?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Magia magia);
        Task DeletarAsync(int id);
    }
}
