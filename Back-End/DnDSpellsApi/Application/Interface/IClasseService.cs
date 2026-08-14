using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IClasseService
    {
        Task<IEnumerable<ClasseResponse>> ObterTodasAsync();
        Task<ClasseResponse?> ObterPorIdAsync(int id);
        Task<ClasseResponse> AdicionarAsync(ClasseRequest request);
        Task<ClasseResponse> AtualizarAsync(ClasseRequest request);
        Task<ClasseResponse> DeletarAsync(int id);
    }
}
