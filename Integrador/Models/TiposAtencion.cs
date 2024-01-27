using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class TiposAtencion
{
    public int Id { get; set; }

    public string? TOnline { get; set; }

    public string? TPrecencial { get; set; }

    public string? TAtencionLocal { get; set; }

    public virtual ICollection<Clinica> Clinicas { get; set; } = new List<Clinica>();

    public virtual ICollection<TipoAtencionReserva> TipoAtencionReservas { get; set; } = new List<TipoAtencionReserva>();
}
