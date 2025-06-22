
using NutritionalKitchen.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseSentry();

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Kitchen Nutrition Microservice",
        Version = "v3.0",
        Description = "API para administrar el preparado de recetas y entrega de comidas"
    });
});

builder.WebHost.UseSentry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
