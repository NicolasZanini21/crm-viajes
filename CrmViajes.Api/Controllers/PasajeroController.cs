using CrmViajes.Api.Data;
using CrmViajes.Api.Dto;
using CrmViajes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmViajes.Api.Controllers;

[ApiController]
[Route("api/pasajeros")]
public class PasajeroController : ControllerBase
{
    private readonly CrmViajesDbContext _context;

    public PasajeroController(CrmViajesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pasajero>>> GetPasajeros()
    {
        return await _context.Pasajeros.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pasajero>> GetPasajero(int id)
    {
        var pasajero = await _context.Pasajeros.FindAsync(id);

        if (pasajero == null)
        {
            return NotFound();
        }

        return pasajero;
    }

    [HttpPost]
public async Task<ActionResult<Pasajero>> PostPasajero(PasajeroDto dto)
{
    var pasajero = new Pasajero
    {
        Nombre = dto.Nombre,
        Apellido = dto.Apellido,
        Dni = dto.Dni,
        Email = dto.Email,
        Telefono = dto.Telefono
    };

    _context.Pasajeros.Add(pasajero);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetPasajero), new { id = pasajero.IdPasajero }, pasajero);
}

[HttpPut("{id}")]
public async Task<IActionResult> PutPasajero(int id, PasajeroDto dto)
{
    var pasajero = await _context.Pasajeros.FindAsync(id);
    if (pasajero == null)
    {
        return NotFound();
    }

    pasajero.Nombre = dto.Nombre;
    pasajero.Apellido = dto.Apellido;
    pasajero.Dni = dto.Dni;
    pasajero.Email = dto.Email;
    pasajero.Telefono = dto.Telefono;

    await _context.SaveChangesAsync();

    return NoContent();
}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePasajero(int id)
    {
        var pasajero = await _context.Pasajeros.FindAsync(id);
        if (pasajero == null)
        {
            return NotFound();
        }

        _context.Pasajeros.Remove(pasajero);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}