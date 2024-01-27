using Integrador.Logica.ServiceUser;
using Integrador.Persistencia;
using Integrador.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddControllers();

// MIS SERVICIO
/************************************************************/
builder.Services.AddScoped<ListarUsuariosService>();    
builder.Services.AddScoped<InsertarUsuarioService>();
builder.Services.AddScoped<UpdateUserService>();
/************************************************************/

// Configuraci�n de la conexi�n de base de datos
builder.Services.AddDbContext<DbIntegradorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// A�adir el servicio de documentaci�n de Swagger
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
