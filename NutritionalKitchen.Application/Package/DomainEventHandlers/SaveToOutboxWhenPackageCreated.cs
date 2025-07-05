using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using MediatR;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Package.Events;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.DomainEventHandlers
{
    [ExcludeFromCodeCoverage]
    public class SaveToOutboxWhenPackageCreated(IOutboxService<DomainEvent> outboxService,
    IUnitOfWork unitOfWork) : INotificationHandler<PackageCreated>
    {
        public async Task Handle(PackageCreated domainEvent, CancellationToken cancellationToken)
        { 
            OutboxMessage<DomainEvent> outboxMessage = new(domainEvent);

            await outboxService.AddAsync(outboxMessage);
            await unitOfWork.CommitAsync(cancellationToken);

        }
    }
}
