using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Application.Dtos.Sector
{
    public class SectorRequestDto
    {
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int CapacidadMaxima { get; set; }
        public bool Disponible { get; set; }
    }
}

