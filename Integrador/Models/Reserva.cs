using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Especialidad { get; set; } = null!;

    public string DesPa { get; set; } = null!;

    public byte Estado { get; set; }

    public int UsId { get; set; }

    public int? DoId { get; set; }

    public int? SuId { get; set; }

    public virtual Médico? Do { get; set; }

    public virtual ICollection<ReservasDoctor> ReservasDoctors { get; set; } = new List<ReservasDoctor>();

    public virtual ICollection<TipoAtencionReserva> TipoAtencionReservas { get; set; } = new List<TipoAtencionReserva>();

    public virtual Usuario Us { get; set; } = null!;
}
