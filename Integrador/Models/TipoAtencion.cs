using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class TipoAtencion
{
    public int Id { get; set; }

    public string TOnline { get; set; } = null!;

    public string TPrecencial { get; set; } = null!;

    public string TAtencionLocal { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
