namespace CrmViajes.Api.Dto;

public class ReservaDto
{
    public int IdPasajero { get; set; }
    public int IdPaquete { get; set; }
    public int IdEstadoReserva { get; set; }
    public int CantidadPersonas { get; set; }
    public decimal? MontoAcordado { get; set; }
}