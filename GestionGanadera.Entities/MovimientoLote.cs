using GestionGanadera.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestionGanadera.Entities.Lote;

namespace GestionGanadera.Entities
{
    public class MovimientoLote
    {
        public int Id { get; set; }
        public EstadoLote EstadoAnterior { get; set; }
        public EstadoLote EstadoNuevo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observaciones { get; set; } = null!;
        public string PersonaResponsable { get; set; } = null!;
        public int LoteId { get; set; }
        public virtual Lote lote { get; set; }
    }
}
