﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrador.Models
{
    public partial class ListarUsuarioPorIDResult
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string dni { get; set; }
        public string correo { get; set; }
        public string username { get; set; }
        public string psw { get; set; }
        public string celular { get; set; }
        public byte estado { get; set; }
        public int? rolUser { get; set; }
    }
}
