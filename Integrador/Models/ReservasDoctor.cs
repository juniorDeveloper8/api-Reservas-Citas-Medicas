using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class ReservasDoctor
{
    public int Id { get; set; }

    public int ReserId { get; set; }

    public int DoId { get; set; }

    public virtual Médico Do { get; set; } = null!;

    public virtual Reserva Reser { get; set; } = null!;
}
