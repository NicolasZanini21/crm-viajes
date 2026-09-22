using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Destino
{
    public int IdDestino { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
