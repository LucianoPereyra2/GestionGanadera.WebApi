using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionGanadera.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoLote
    {
        EnEspera,
        [Display(Name ="En Corral")]
        EnCorral,
        Pesado,
        Retirado
    }
}
