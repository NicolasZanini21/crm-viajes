using CrmViajes.Api.Data;
using CrmViajes.Api.Dto;
using CrmViajes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmViajes.Api.Controllers;

[ApiController]
[Route("api/reservas")]
public class ReservaController : ControllerBase
{
    private readonly CrmViajesDbContext _context;

    public ReservaController(CrmViajesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
    {
        return await _context.Reservas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reserva>> GetReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);

        if (reserva == null)
        {
            return NotFound();
        }

        return reserva;
    }

    [HttpPost]
public async Task<ActionResult<Reserva>> PostReserva(ReservaDto dto)
{
    var reserva = new Reserva
    {
        IdPasajero = dto.IdPasajero,
        IdPaquete = dto.IdPaquete,
        IdEstadoReserva = dto.IdEstadoReserva,
        CantidadPersonas = dto.CantidadPersonas,
        MontoAcordado = dto.MontoAcordado
    };

    _context.Reservas.Add(reserva);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetReserva), new { id = reserva.IdReserva }, reserva);
}

[HttpPut("{id}")]
public async Task<IActionResult> PutReserva(int id, ReservaDto dto)
{
    var reserva = await _context.Reservas.FindAsync(id);
    if (reserva == null)
    {
        return NotFound();
    }

    reserva.IdPasajero = dto.IdPasajero;
    reserva.IdPaquete = dto.IdPaquete;
    reserva.IdEstadoReserva = dto.IdEstadoReserva;
    reserva.CantidadPersonas = dto.CantidadPersonas;
    reserva.MontoAcordado = dto.MontoAcordado;

    await _context.SaveChangesAsync();

    return NoContent();
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}