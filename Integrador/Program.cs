using Integrador.Persistencia;
using Microsoft.EntityFrameworkCore;
using Integrador.Logica.UserServices;
using Integrador.Logica.ReservaServices;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddControllers();

// Configuración de la conexión de base de datos
builder.Services.AddDbContext<DbIntegradorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/**CONFIGURACION DE CORS**/
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

// MIS SERVICIO
/************************************************************/
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<InsertUserService>();
builder.Services.AddScoped<UpdateUserService>();

builder.Services.AddScoped<ListReservasService>();
builder.Services.AddScoped<InsertReservaService>();
builder.Services.AddScoped<UpdateReservaService>();
builder.Services.AddScoped<DeleteReservaService>();

/************************************************************/

// Añadir el servicio de documentación de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
