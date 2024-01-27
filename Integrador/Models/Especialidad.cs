using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Especialidad
{
    public int Id { get; set; }

    public string? ENomre { get; set; }

    public string? EDecripcion { get; set; }

    public string? EArea { get; set; }

    public string? ECodigo { get; set; }

    public string? EDescripcion { get; set; }

    public int DoId { get; set; }

    public virtual Médico Do { get; set; } = null!;
}
