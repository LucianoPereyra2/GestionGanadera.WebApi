using GestionGanadera.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Entities
{
    public class Sector : IEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int CapacidadMaxima { get; set; }
        public bool Disponible { get; set; } 

    }
}
