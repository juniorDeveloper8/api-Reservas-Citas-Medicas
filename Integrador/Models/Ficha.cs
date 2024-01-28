using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Ficha
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime Hora { get; set; }

    public int UsuId { get; set; }

    public int DocId { get; set; }

    public virtual Usuario Doc { get; set; } = null!;

    public virtual Usuario Usu { get; set; } = null!;
}
