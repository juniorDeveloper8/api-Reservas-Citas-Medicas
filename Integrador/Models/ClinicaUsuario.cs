using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class ClinicaUsuario
{
    public int Id { get; set; }

    public int Usuario { get; set; }

    public int Clinica { get; set; }

    public virtual Clinica ClinicaNavigation { get; set; } = null!;

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
