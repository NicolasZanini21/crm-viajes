using CrmViajes.Api.Data;
using CrmViajes.Api.Dto;
using CrmViajes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmViajes.Api.Controllers;

[ApiController]
[Route("api/destinos")]
public class DestinoController : ControllerBase
{
    private readonly CrmViajesDbContext _context;

    public DestinoController(CrmViajesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destino>>> GetDestinos()
    {
        return await _context.Destinos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destino>> GetDestino(int id)
    {
        var destino = await _context.Destinos.FindAsync(id);

        if (destino == null)
        {
            return NotFound();
        }

        return destino;
    }

   [HttpPost]
public async Task<ActionResult<Destino>> PostDestino(DestinoDto dto)
{
    var destino = new Destino
    {
        Nombre = dto.Nombre,
        Pais = dto.Pais,
        Descripcion = dto.Descripcion
    };

    _context.Destinos.Add(destino);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetDestino), new { id = destino.IdDestino }, destino);
}

[HttpPut("{id}")]
public async Task<IActionResult> PutDestino(int id, DestinoDto dto)
{
    var destino = await _context.Destinos.FindAsync(id);
    if (destino == null)
    {
        return NotFound();
    }

    destino.Nombre = dto.Nombre;
    destino.Pais = dto.Pais;
    destino.Descripcion = dto.Descripcion;

    await _context.SaveChangesAsync();

    return NoContent();
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestino(int id)
    {
        var destino = await _context.Destinos.FindAsync(id);
        if (destino == null)
        {
            return NotFound();
        }

        _context.Destinos.Remove(destino);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}