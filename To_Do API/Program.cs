using Business.IService;
using Business.Service;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string DefaultConnection not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
builder.Services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));

builder.Services.AddScoped(typeof(ITareasRepository), typeof(TareasRepository));
builder.Services.AddScoped(typeof(ITareasService), typeof(TareasService));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Shows UseCors with CorsPolicyBuilder.

app.UseCors(builder =>
{
    builder
    .WithOrigins("http://170.247.0.104:2180")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});

#endregion


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
