using Application.Dtos;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class MagiaService : IMagiaService
    {
        private readonly IMagiaRepository _repository;

        public MagiaService(IMagiaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MagiaResponse>> ObterTodasAsync()
        {
            var magias = await _repository.ObterTodasAsync();

            //Mapeamento manual de entidades para DTOs
            return magias.Select(m => new MagiaResponse
            {
                Id = m.Id,
                Nome = m.Nome,
                Nivel = m.Nivel,
                Escola = m.Escola,
                Classes = m.Classes.Select(c => c.Nome).ToList()
            });
        }

        public async Task<MagiaResponse?> ObterPorIdAsync(int id)
        {
            var magia = await _repository.ObterPorIdAsync(id);
            if (magia == null) return null;
            return new MagiaResponse
            {
                Id = magia.Id,
                Nome = magia.Nome,
                Nivel = magia.Nivel,
                Escola = magia.Escola,
                Classes = magia.Classes.Select(c => c.Nome).ToList()
            };
        }

        public async Task AdicionarAsync(MagiaRequest request)
        {
            var magia = new Domain.Entities.Magia
            {
                Nome = request.Nome,
                Nivel = request.Nivel,
                Escola = request.Escola
            };
            await _repository.AdicionarAsync(magia);
        }

        public async Task AtualizarAsync(MagiaRequest request)
        {
            var magia = new Domain.Entities.Magia
            {
                Nome = request.Nome,
                Nivel = request.Nivel,
                Escola = request.Escola,
                Classes = request.ClassesIds.Select(id => new Domain.Entities.Classe { Id = id }).ToList()
            };
            await _repository.AtualizarAsync(magia);
        }

        public async Task DeletarAsync(int id)
        {
            await _repository.DeletarAsync(id);
        }
    }
}
