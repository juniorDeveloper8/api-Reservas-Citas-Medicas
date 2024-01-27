using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Médico
{
    public int Id { get; set; }

    public string DNombre { get; set; } = null!;

    public string DApellido { get; set; } = null!;

    public string DArea { get; set; } = null!;

    public string DDni { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public byte Estado { get; set; }

    public virtual ICollection<Clinica> Clinicas { get; set; } = new List<Clinica>();

    public virtual ICollection<Especialidad> Especialidads { get; set; } = new List<Especialidad>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<ReservasDoctor> ReservasDoctors { get; set; } = new List<ReservasDoctor>();
}
