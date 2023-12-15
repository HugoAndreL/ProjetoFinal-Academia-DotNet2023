using DesafioFinal.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
