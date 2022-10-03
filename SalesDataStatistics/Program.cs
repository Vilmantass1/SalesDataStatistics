using Microsoft.OpenApi.Models;
using SalesDataStatistics.Data;
using SalesDataStatistics.Services;
using SalesDataStatistics.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<IXMLReaderService, XMLReaderService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Mano API Services", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mano API Services");
        c.RoutePrefix = "WebServices";
    } );
}

app.UseAuthorization();

app.MapControllers();

app.Run();
