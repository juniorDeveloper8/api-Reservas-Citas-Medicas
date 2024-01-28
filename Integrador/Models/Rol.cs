using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Rol1 { get; set; } = null!;

    public int Usuario { get; set; }

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
