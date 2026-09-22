using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Paquete
{
    public int IdPaquete { get; set; }

    public int IdDestino { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaSalida { get; set; }

    public DateOnly FechaRegreso { get; set; }

    public decimal PrecioBase { get; set; }

    public string? Descripcion { get; set; }

    public virtual Destino IdDestinoNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
