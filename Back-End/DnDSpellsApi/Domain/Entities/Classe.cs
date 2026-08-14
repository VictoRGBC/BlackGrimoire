using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Classe
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        //Propriedade de navegação para a relação N:M
        public ICollection<Magia> Magias { get; set; } = new List<Magia>();
    }
}
