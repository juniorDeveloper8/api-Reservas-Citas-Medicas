using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Clinica
{
    public int Id { get; set; }

    public string ClinicaNombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public int DoId { get; set; }

    public int TiId { get; set; }

    public virtual Médico Do { get; set; } = null!;

    public virtual TiposAtencion Ti { get; set; } = null!;
}
