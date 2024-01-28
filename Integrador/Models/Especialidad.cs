using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Especialidad
{
    public int Id { get; set; }

    public string ENomre { get; set; } = null!;

    public string EDecripcion { get; set; } = null!;

    public string EArea { get; set; } = null!;

    public string ECodigo { get; set; } = null!;

    public string EDescripcion { get; set; } = null!;

    public virtual ICollection<DotorEspecialidad> DotorEspecialidads { get; set; } = new List<DotorEspecialidad>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
