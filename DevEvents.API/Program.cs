using DevEvents.API.Mappers;
using DevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevEventsCs");

builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(DevEventProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(C=>
{
    C.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevEvents.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Breno Carvalho",
            Email = "breno@mailsample.com.br",
            Url = new Uri("https://meuprotifolio123.com.br")
        }
    
    });

    var smlFile = "DevEvents.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, smlFile);
    C.IncludeXmlComments(xmlPath);
});

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
