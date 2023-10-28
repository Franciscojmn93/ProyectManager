using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region
//inyectar dependencias aqui IDAL, IUnidaddeTrabajo, ISerivices//
builder.Services.AddDbContext<ProyectManagerContext>();
builder.Services.AddScoped<IUnidadeDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IDepartamentoDAL, DepartamentosDALImpl>();
builder.Services.AddScoped<IDepartamentosService, DepartamentosService>();
builder.Services.AddScoped<ICargosDAL, CargosDALImpl>();
builder.Services.AddScoped<ICargosService, CargosService>();
builder.Services.AddScoped<IUsuariosDAL, UsuariosDALImpl>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IRolDAL, RolDALImpl>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IEstadosDAL, EstadosDALImpl>();
builder.Services.AddScoped<IEstadosService, EstadosService>();



#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
