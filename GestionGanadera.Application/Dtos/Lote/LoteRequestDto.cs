using GestionGanadera.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Application.Dtos.Lote
{
    public class LoteRequestDto
    {
        public string Codigo { get; set; } = null!;
        public int CantidadCabezas { get; set; }
        public EspecieAnimal Especie { get; set; }
        public string Categoria { get; set; } = null!;
        public EstadoLote Estado { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public DateTime FechaHoraEgreso { get; set; }
        public int ClienteId { get; set; }
    }
}
