using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Pasajero
{
    public int IdPasajero { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaAlta { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
