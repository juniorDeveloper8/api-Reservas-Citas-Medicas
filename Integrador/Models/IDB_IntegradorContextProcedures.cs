﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Integrador.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Integrador.Models
{
    public partial interface IDB_IntegradorContextProcedures
    {
        Task<List<ActualizarClinicasResult>> ActualizarClinicasAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ActualizarEspecialidadesResult>> ActualizarEspecialidadesAsync(int? parametro1, string parametro2, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> ActualizarReservaAsync(int? ReservaID, DateTime? NuevaFecha, int? NuevoTipoAtencionID, int? NuevaClinicaID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> ActualizarUsuarioAsync(int? UserID, string Nombre, string Apellido, string TipoDocumento, string DNI, string Correo, string Username, string Password, string Celular, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> deleteEspecialidadAsync(int? especialidad_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteReservaAsync(int? ReservaID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> insertarEspecialidadAsync(string e_nombre, string e_descripcion, string e_area, string e_codigo, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertarFichaAsync(string descripcion, DateTime? fecha, TimeSpan? hora, int? usu_id, int? doc_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertarReservaAsync(DateTime? Fecha, string Sintomas, byte? Estado, int? UserID, int? DoctorID, int? TipoAtencionID, int? ClinicaID, int? EspecialidadID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertarUsuarioAsync(string Nombre, string Apellido, string TipoDocumento, string DNI, string Correo, string Username, string Password, string Celular, int? RolUser, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarClinicasResult>> ListarClinicasAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarDoctoresResult>> ListarDoctoresAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarEspecialidadesResult>> ListarEspecialidadesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarReservaResult>> ListarReservaAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarReservaPorDNIResult>> ListarReservaPorDNIAsync(int? DNI, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarReservasResult>> ListarReservasAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarTipoAtencionResult>> ListarTipoAtencionAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarUsuarioPorIDResult>> ListarUsuarioPorIDAsync(int? UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarUsuarioPorNombreYCedulaResult>> ListarUsuarioPorNombreYCedulaAsync(string Nombre, string Cedula, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ListarUsuariosResult>> ListarUsuariosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
