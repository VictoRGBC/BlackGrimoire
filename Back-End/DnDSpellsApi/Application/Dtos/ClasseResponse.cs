using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ClasseResponse
    {
        public string Nome { get; set; } = string.Empty;
        public List<string> Magias { get; set; } = new();
    }
}
