using Integrador.DTO.especialidad;
using Integrador.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Integrador.Logica.EspecialidadService
{
    public class ListEspecialidadService
    {
        private readonly DbIntegradorContext _context;
        private readonly DbIntegradorContextProcedures _contextProcedures;

        public ListEspecialidadService(DbIntegradorContext context, DbIntegradorContextProcedures contextProcedures)
        {
            _context = context;
            _contextProcedures = contextProcedures;
        }

        public async Task<List<EspecialidadDTO>> ListarEspecialidadesAsync()
        {
            try
            {
                var returnValue = new OutputParameter<int>(); // Parámetro de salida para el valor de retorno del procedimiento almacenado
                var especialidades = await _contextProcedures.ListarEspecialidadesAsync(returnValue); // Llama al método del contexto de procedimientos

                // Asigna el valor del parámetro de salida si es necesario
                var returnValueValue = returnValue.Value;

                var especialidadesDTO = especialidades.Select(e => new EspecialidadDTO
                {
                    Id = e.id,
                    ENombre = e.e_nombre,
                    EDescripcion = e.e_descripcion,
                    EArea = e.e_area,
                    ECodigo = e.e_codigo
                }).ToList();

                return especialidadesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las especialidades.", ex);
            }
        }
    }
}
