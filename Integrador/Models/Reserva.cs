using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Sintomas { get; set; } = null!;

    public byte Estado { get; set; }

    public int UsId { get; set; }

    public int DocId { get; set; }

    public int AtId { get; set; }

    public int CliId { get; set; }

    public int EspecialidadId { get; set; }

    public virtual TipoAtencion At { get; set; } = null!;

    public virtual Clinica Cli { get; set; } = null!;

    public virtual Usuario Doc { get; set; } = null!;

    public virtual Especialidad Especialidad { get; set; } = null!;

    public virtual Usuario Us { get; set; } = null!;
}
