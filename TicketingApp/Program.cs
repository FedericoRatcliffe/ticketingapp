using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TicketingApp.Persistence.DbContexts;


var builder = WebApplication.CreateBuilder(args);

//  Configuración de la cadena de conexión
builder.Services.AddDbContext<TicketingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TicketingDb")));

//  Agregar servicios para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuración de autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

var app = builder.Build();

//jwt
app.UseAuthentication();
app.UseAuthorization();


// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // UI en /swagger
}

//app.UseAuthorization(); // si tenés [Authorize] más adelante

app.MapControllers(); // asegúrate de tener esto si usás controladores

app.Run();
