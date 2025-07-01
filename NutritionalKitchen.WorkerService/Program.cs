using Joseco.Outbox.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NutritionalKitchen.Application;
using NutritionalKitchen.Domain;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Infrastructure; 

var builder = Host.CreateApplicationBuilder(args);

string serviceName = "nutritionalkitchen.worker-service";


builder.Services.AddInfrastructure(builder.Configuration, builder.Environment, serviceName);
builder.Services.AddOutboxBackgroundService<DomainEvent>();

var host = builder.Build();
host.Run();