using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ClasseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> MagiasIds { get; set; } = new(); // IDs das magias associadas
        public string Nome { get; internal set; }
    }
}
