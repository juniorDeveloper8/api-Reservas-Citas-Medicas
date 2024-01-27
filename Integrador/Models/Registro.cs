using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Registro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Psw { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public byte Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
