using Application.Dtos;
using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ClasseService : IClasseService
    {
        private readonly IClasseRepository _repository;

        public ClasseService(IClasseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClasseResponse>> ObterTodasAsync()
        {
            var classes = await _repository.ObterTodasAsync();
            return classes.Select(c => new ClasseResponse
            {
                Nome = c.Nome,
                Magias = c.Magias.Select(m => m.Nome).ToList()
            });
        }

        public async Task<ClasseResponse?> ObterPorIdAsync(int id)
        {
            var classe = await _repository.ObterPorIdAsync(id);
            if (classe == null) return null;
            return new ClasseResponse
            {
                Nome = classe.Nome,
                Magias = classe.Magias.Select(m => m.Nome).ToList()
            };
        }

        public async Task<ClasseResponse> AdicionarAsync(ClasseRequest request)
        {
            var classe = new Classe
            {
                Nome = request.Nome
            };
            await _repository.AdicionarAsync(classe);
            return new ClasseResponse
            {
                Nome = classe.Nome,
                Magias = new List<string>()
            };
        }

        public async Task<ClasseResponse> AtualizarAsync(ClasseRequest request)
        {
            var classe = new Classe
            {
                Nome = request.Nome
            };
            await _repository.AtualizarAsync(classe);
            return new ClasseResponse
            {
                Nome = classe.Nome,
                Magias = new List<string>()
            };
        }

        public async Task<ClasseResponse> DeletarAsync(int id)
        {
            var classe = await _repository.ObterPorIdAsync(id);
            if (classe == null) return null;
            await _repository.DeletarAsync(id);
            return new ClasseResponse
            {
                Nome = classe.Nome,
                Magias = classe.Magias.Select(m => m.Nome).ToList()
            };
        }
    }
}
