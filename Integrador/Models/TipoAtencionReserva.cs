using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class TipoAtencionReserva
{
    public int Id { get; set; }

    public int TiId { get; set; }

    public int ReseId { get; set; }

    public virtual Reserva Rese { get; set; } = null!;

    public virtual TiposAtencion Ti { get; set; } = null!;
}
