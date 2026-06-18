using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Application.Dtos.Empleado
{
    public class EmpleadoRequestDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public bool Activo { get; set; } = true;
    }
}
