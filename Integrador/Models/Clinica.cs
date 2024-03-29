﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Clinica
{
    public int Id { get; set; }

    public string ClinicaNombre { get; set; }

    public string Direccion { get; set; }

    public string Ruc { get; set; }

    public byte? Estado { get; set; }

    public virtual ICollection<ClinicaUsuario> ClinicaUsuarios { get; set; } = new List<ClinicaUsuario>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}