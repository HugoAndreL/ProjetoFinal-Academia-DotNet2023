using DesafioFinal.Server;
using DesafioFinal.Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(
    opt =>
    {
        opt.AddPolicy(MyAllowSpecificOrigins,
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sistema de Gerenciamento de Sistemas (SGS)",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Hugo André Lucena",
            Email = "hugo.andre.lucena@outlook.com",
            Url = new Uri("https://www.linkedin.com/in/hugo-andré-lucena-968a42207/")
        }
    });

    var xmlFile = "DesafioFinal.Server.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var tokenKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikh1Z28gQW5kcsOpIiwibmJmIjoxNzA0MjA3NTMxLCJleHAiOjE3MDQyMTExMzEsImlhdCI6MTcwNDIwNzUzMX0.LLubk9_RaCKCGTsh71jSASsHg0_o1VL4iz027D0hj68";
var key = Encoding.ASCII.GetBytes(tokenKey);

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(
    auth =>
    {
        // remova essa parte ao publicar
        auth.RequireHttpsMetadata = false;

        auth.SaveToken = true;
        auth.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            // Remova essas duas linhas ao publicar
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);

builder.Services.AddSingleton<IJWTAuthManager>(new JWTAuthManager(tokenKey));

string strCon = builder.Configuration.GetConnectionString("HospitalDBcon");

builder.Services.AddDbContext<HospitalContext>(opt => opt.UseSqlServer(strCon));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
