using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Destino
{
    public int IdDestino { get; set; }

    public string Destino1 { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public int IdContinente { get; set; }

    public virtual Continente IdContinenteNavigation { get; set; } = null!;

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
