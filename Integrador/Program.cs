using Integrador.Logica;
using Integrador.Logica.ClinicaService;
using Integrador.Logica.DoctorService;
using Integrador.Logica.EspecialidadService;
using Integrador.Logica.FichaServices;
using Integrador.Logica.ReservaServices;
using Integrador.Logica.UserServices;
using Integrador.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Configuración de la conexión de base de datos
builder.Services.AddDbContext<DbIntegradorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CONFIGURACION DE CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Registrar DbIntegradorContextProcedures
builder.Services.AddScoped<DbIntegradorContextProcedures>();

// MIS SERVICIOS
/************************************************************/
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<InsertUserService>();
builder.Services.AddScoped<UpdateUserService>();

builder.Services.AddScoped<ListReservasService>();
builder.Services.AddScoped<ListReservaXDNIService>();
builder.Services.AddScoped<InsertReservaService>();
builder.Services.AddScoped<UpdateReservaService>();
builder.Services.AddScoped<DeleteReservaService>();

builder.Services.AddScoped<ListEspecialidadService>();
builder.Services.AddScoped<InsertEspecialidadService>();
builder.Services.AddScoped<UpdateEspecialidadService>();
builder.Services.AddScoped<DeleteEspecialidadService>();

builder.Services.AddScoped<ListDoctorService>();
builder.Services.AddScoped<InsertDoctorService>();
builder.Services.AddScoped<UpdateDoctorService>();
builder.Services.AddScoped<DeleteDoctorService>();

builder.Services.AddScoped<ListClinicaService>();
builder.Services.AddScoped<UpdateClinicaService>();
builder.Services.AddScoped<InsertClinicaService>();
builder.Services.AddScoped<DeleteClinicaService>();

// TOCA CORREGIR
builder.Services.AddScoped<ListFichaService>();
builder.Services.AddScoped<InsertFichaService>();
/************************************************************/

// Añadir el servicio de documentación de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins); // Agregar CORS
app.MapControllers();

app.Run();
