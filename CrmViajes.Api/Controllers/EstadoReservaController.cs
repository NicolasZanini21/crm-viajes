using CrmViajes.Api.Data;
using CrmViajes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmViajes.Api.Controllers;

[ApiController]
[Route("api/estados-reserva")]
public class EstadoReservaController : ControllerBase
{
    private readonly CrmViajesDbContext _context;

    public EstadoReservaController(CrmViajesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstadoReserva>>> GetEstadosReserva()
    {
        return await _context.EstadoReservas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstadoReserva>> GetEstadoReserva(int id)
    {
        var estado = await _context.EstadoReservas.FindAsync(id);

        if (estado == null)
        {
            return NotFound();
        }

        return estado;
    }
}