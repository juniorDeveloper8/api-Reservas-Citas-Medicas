﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Integrador.Models;

public partial class DotorEspecialidad
{
    public int Id { get; set; }

    public int DocId { get; set; }

    public int EspecialidadId { get; set; }

    public virtual Usuario Doc { get; set; }

    public virtual Especialidad Especialidad { get; set; }
}