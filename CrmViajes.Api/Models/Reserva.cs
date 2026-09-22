using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdPasajero { get; set; }

    public int IdPaquete { get; set; }

    public int IdEstadoReserva { get; set; }

    public int CantidadPersonas { get; set; }

    public decimal? MontoAcordado { get; set; }

    public DateOnly FechaReserva { get; set; }

    public DateOnly FechaUltimaActualizacion { get; set; }

    public virtual EstadoReserva IdEstadoReservaNavigation { get; set; } = null!;

    public virtual Paquete IdPaqueteNavigation { get; set; } = null!;

    public virtual Pasajero IdPasajeroNavigation { get; set; } = null!;
}
