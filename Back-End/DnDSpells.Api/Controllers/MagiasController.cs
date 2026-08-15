using DnDSpells.Application.Interfaces;
using DnDSpells.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DnDSpells.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagiasController : ControllerBase
{
    private readonly IMagiaRepository _repository;

    public MagiasController(IMagiaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var magias = await _repository.GetAllAsync();
        return Ok(magias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var magia = await _repository.GetByIdAsync(id);

        if (magia == null) return NotFound();

        return Ok(magia);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Magia magia)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdMagia = await _repository.AddAsync(magia);

        // Retorna 201 Created e o local onde o recurso recém-criado pode ser acessado
        return CreatedAtAction(nameof(GetById), new { id = createdMagia.Id }, createdMagia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Magia magia)
    {
        if (id != magia.Id) return BadRequest("O ID da magia na rota não corresponde ao ID do corpo da requisição.");

        var existingMagia = await _repository.GetByIdAsync(id);
        if (existingMagia == null) return NotFound();

        // Atualizando os campos
        existingMagia.Nome = magia.Nome;
        existingMagia.Nivel = magia.Nivel;
        existingMagia.Escola = magia.Escola;
        existingMagia.TempoConjuracao = magia.TempoConjuracao;
        existingMagia.Alcance = magia.Alcance;
        existingMagia.Duracao = magia.Duracao;
        existingMagia.Concentracao = magia.Concentracao;
        existingMagia.Ritual = magia.Ritual;
        existingMagia.Componentes = magia.Componentes;
        existingMagia.Descricao = magia.Descricao;
        existingMagia.DescricaoNiveisSuperiores = magia.DescricaoNiveisSuperiores;

        await _repository.UpdateAsync(existingMagia);

        return NoContent(); // Retorna 204 indicando que deu tudo certo, mas não há conteúdo para retornar
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var magia = await _repository.GetByIdAsync(id);
        if (magia == null) return NotFound();

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}