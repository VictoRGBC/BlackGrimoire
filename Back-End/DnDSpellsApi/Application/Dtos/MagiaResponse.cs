using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class MagiaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Nivel { get; set; }
        public string Escola { get; set; } = string.Empty;
        public string Alcance { get; set; } = string.Empty;
        public List<string> Classes { get; set; } = new();
    }
}
