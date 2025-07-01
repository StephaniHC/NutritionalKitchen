using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalKitchen.Application.Label.CreateLabel;
using NutritionalKitchen.Application.Label.UpdateLabel;
using NutritionalKitchen.Integration.Labeled;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.RabbitMQ.Consumers
{
    public class LabeledUpdateConsumer(IMediator mediator) : IIntegrationMessageConsumer<DeliberyUpdate>
    {
        public async Task HandleAsync(DeliberyUpdate message, CancellationToken cancellationToken)
        {
            var address = $"{message.Street} {message.Number}";
            UpdateLabelCommand command = new(
                message.DeliveryDayId,
                message.ContractId, 
                address,
                true
            );
            await mediator.Send(command, cancellationToken);
        }
    }
}
