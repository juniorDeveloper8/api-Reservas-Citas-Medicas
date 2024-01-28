using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Psw { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public byte Estado { get; set; }

    public virtual ICollection<ClinicaUsuario> ClinicaUsuarios { get; set; } = new List<ClinicaUsuario>();

    public virtual ICollection<DotorEspecialidad> DotorEspecialidads { get; set; } = new List<DotorEspecialidad>();

    public virtual ICollection<Ficha> FichaDocs { get; set; } = new List<Ficha>();

    public virtual ICollection<Ficha> FichaUsus { get; set; } = new List<Ficha>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Reserva> ReservaDocs { get; set; } = new List<Reserva>();

    public virtual ICollection<Reserva> ReservaUs { get; set; } = new List<Reserva>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
