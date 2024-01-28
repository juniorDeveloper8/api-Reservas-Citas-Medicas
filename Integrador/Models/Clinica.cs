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

    public virtual ICollection<ClinicaUsuario> ClinicaUsuarios { get; set; } = new List<ClinicaUsuario>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
