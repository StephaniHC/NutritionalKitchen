using Joseco.Communication.External.Contracts.Services;
using Joseco.Outbox.Contracts.Model;
using MediatR;
using Microsoft.VisualBasic;
using NutritionalKitchen.Domain.Package.Events;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.OutboxMessageHandlers
{
    class PublishPackageCreated (IExternalPublisher integrationBusService) : INotificationHandler<OutboxMessage<PackageCreated>>
    {
        public async Task Handle(OutboxMessage<PackageCreated> notification, CancellationToken cancellationToken)
        {
            Integration.Package.PackageCreated message = new(
                notification.Content.packageId,
                notification.Content.status,
                notification.CorrelationId,
                "kitchen"
            );

            await integrationBusService.PublishAsync(message);
        }
    }
}
