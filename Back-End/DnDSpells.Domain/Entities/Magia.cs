namespace DnDSpells.Domain.Entities;

public class Magia
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public string Escola { get; set; } = string.Empty;
    public string TempoConjuracao { get; set; } = string.Empty;
    public string Alcance { get; set; } = string.Empty;
    public string Duracao { get; set; } = string.Empty;

    // Tipos booleanos fazem sentido para estes campos no D&D
    public bool Concentracao { get; set; }
    public bool Ritual { get; set; }

    public string Componentes { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string? DescricaoNiveisSuperiores { get; set; } // Pode ser nulo, nem toda magia tem.
    public string? Classes { get; set; } // Pode ser nulo, nem toda magia tem.
}