using CrmViajes.Api.Data;
using CrmViajes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmViajes.Api.Controllers;

[ApiController]
[Route("api/continentes")]
public class ContinenteController : ControllerBase
{
    private readonly CrmViajesDbContext _context;

    public ContinenteController(CrmViajesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Continente>>> GetContinentes()
    {
        return await _context.Continentes.ToListAsync();
    }
}