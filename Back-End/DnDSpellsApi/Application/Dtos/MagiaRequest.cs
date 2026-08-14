using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class MagiaRequest
    {
        public string Nome { get; set; } = string.Empty;
        public int Nivel { get; set; }
        public string Escola { get; set; } = string.Empty;
        public List<int> ClassesIds { get; set; } = new(); // IDs das classes associadas
    }
}
