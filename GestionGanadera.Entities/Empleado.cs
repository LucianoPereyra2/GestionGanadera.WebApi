using GestionGanadera.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Entities
{
    public class Empleado : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public bool Activo { get; set; } = true;
    }
}
