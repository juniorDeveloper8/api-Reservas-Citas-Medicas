using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int ReId { get; set; }

    public virtual Registro Re { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
