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
    public class PackageConsumer(IMediator mediator) : IIntegrationMessageConsumer<Package>
    {
        public async Task HandleAsync(Package message, CancellationToken cancellationToken)
        {
            CreatePackageCommand command = new(
                "Pending",
                Guid.NewGuid()
            );
            await mediator.Send(command, cancellationToken);
        }
    }
}
