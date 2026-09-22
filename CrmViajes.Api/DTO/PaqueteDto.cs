namespace CrmViajes.Api.Dto;

public class PaqueteDto
{
    public int IdDestino { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateOnly FechaSalida { get; set; }
    public DateOnly FechaRegreso { get; set; }
    public decimal PrecioBase { get; set; }
    public string? Descripcion { get; set; }
}