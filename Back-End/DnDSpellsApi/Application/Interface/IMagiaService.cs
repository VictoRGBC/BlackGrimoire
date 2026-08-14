using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IMagiaService
    {
        Task<IEnumerable<MagiaResponse>> ObterTodasAsync();
        Task<MagiaResponse?> ObterPorIdAsync(int id);
        Task AdicionarAsync(MagiaRequest request);
        Task AtualizarAsync(MagiaRequest request);
        Task DeletarAsync(int id);
    }
}
