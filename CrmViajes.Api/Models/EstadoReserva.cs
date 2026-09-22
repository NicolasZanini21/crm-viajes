using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class EstadoReserva
{
    public int IdEstadoReserva { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
