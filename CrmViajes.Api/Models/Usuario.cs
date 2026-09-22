using System;
using System.Collections.Generic;

namespace CrmViajes.Api.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateOnly FechaAlta { get; set; }
}
