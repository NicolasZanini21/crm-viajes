using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Continente
{
    public int IdContinente { get; set; }

    public string NombreContinente { get; set; } = null!;

    public virtual ICollection<Destino> Destinos { get; set; } = new List<Destino>();
}