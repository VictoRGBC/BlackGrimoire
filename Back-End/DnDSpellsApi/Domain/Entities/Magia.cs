using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Magia
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Nivel { get; set; }
        public string Escola { get; set; } = string.Empty;
        public string TempoConjuracao { get; set; } = string.Empty;
        public string Alcance { get; set; } = string.Empty;
        public string Duracao { get; set; } = string.Empty;
        public bool Concentracao { get; set; }
        public bool Ritual { get; set; }
        public string Componentes { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? DescricaoNiveisSuperiores { get; set; }

        //Propriedade de navegação para a relação N:M
        public ICollection<Classe> Classes { get; set; } = new List<Classe>();
    }
}
