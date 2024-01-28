using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Log
{
    public int Id { get; set; }

    public int? Intentos { get; set; }

    public byte Estado { get; set; }

    public int Usuario { get; set; }

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
