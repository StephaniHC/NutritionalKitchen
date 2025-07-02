using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Integration.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.RabbitMQ.Consumers
{
    public class PackageConsumer(IMediator mediator) : IIntegrationMessageConsumer<PackageCreated>
    {
        public async Task HandleAsync(PackageCreated message, CancellationToken cancellationToken)
        {
            CreatePackageCommand command = new(
                "Pending",
                Guid.NewGuid()
            );
            await mediator.Send(command, cancellationToken);
        }
    }
}
