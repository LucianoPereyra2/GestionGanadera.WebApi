using GestionGanadera.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Entities
{
    public class EspecieAnimal : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}