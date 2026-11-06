using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionGanadera.Enums
{
    public enum EstadoLote
    {
        Espera,
        Corral,
        Pesado,
        Retirado
    }
}
