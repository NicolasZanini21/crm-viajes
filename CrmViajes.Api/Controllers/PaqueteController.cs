using CrmViajes.Api.Data;
using CrmViajes.Api.Dto;
using CrmViajes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmViajes.Api.Controllers;

[ApiController]
[Route("api/paquetes")]
public class PaqueteController : ControllerBase
{
    private readonly CrmViajesDbContext _context;

    public PaqueteController(CrmViajesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Paquete>>> GetPaquetes()
    {
        return await _context.Paquetes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paquete>> GetPaquete(int id)
    {
        var paquete = await _context.Paquetes.FindAsync(id);

        if (paquete == null)
        {
            return NotFound();
        }

        return paquete;
    }

   [HttpPost]
public async Task<ActionResult<Paquete>> PostPaquete(PaqueteDto dto)
{
    var paquete = new Paquete
    {
        IdDestino = dto.IdDestino,
        Nombre = dto.Nombre,
        FechaSalida = dto.FechaSalida,
        FechaRegreso = dto.FechaRegreso,
        PrecioBase = dto.PrecioBase,
        Descripcion = dto.Descripcion
    };

    _context.Paquetes.Add(paquete);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetPaquete), new { id = paquete.IdPaquete }, paquete);
}

[HttpPut("{id}")]
public async Task<IActionResult> PutPaquete(int id, PaqueteDto dto)
{
    var paquete = await _context.Paquetes.FindAsync(id);
    if (paquete == null)
    {
        return NotFound();
    }

    paquete.IdDestino = dto.IdDestino;
    paquete.Nombre = dto.Nombre;
    paquete.FechaSalida = dto.FechaSalida;
    paquete.FechaRegreso = dto.FechaRegreso;
    paquete.PrecioBase = dto.PrecioBase;
    paquete.Descripcion = dto.Descripcion;

    await _context.SaveChangesAsync();

    return NoContent();
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaquete(int id)
    {
        var paquete = await _context.Paquetes.FindAsync(id);
        if (paquete == null)
        {
            return NotFound();
        }

        _context.Paquetes.Remove(paquete);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}