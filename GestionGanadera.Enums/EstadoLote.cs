using System;
using System.Collections.Generic;
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
        EnCorral,
        Pesado,
        Retirado
    }
}
