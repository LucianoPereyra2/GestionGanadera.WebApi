using GestionGanadera.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.Application.Dtos.Pesaje
{
    public class PesajeResponseDto
    {
        public int Id { get; set; }
        public decimal PesoNeto { get; set; }
        public TipoPesaje TipoPesaje { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observaciones { get; set; } = null!;
        public int LoteId { get; set; }
    }
}
