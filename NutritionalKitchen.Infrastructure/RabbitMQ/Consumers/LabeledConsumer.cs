using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalKitchen.Application.Label.CreateLabel; 
using NutritionalKitchen.Integration.Labeled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.RabbitMQ.Consumers
{
    public class LabeledConsumer(IMediator mediator) : IIntegrationMessageConsumer<Labeled>
    {
        public async Task HandleAsync(Labeled message, CancellationToken cancellationToken)

        {
            foreach (var deliveryDay in message.DeliveryDays)
            { 
                var productionDate = deliveryDay.Date;
                var expirationDate = productionDate.AddDays(1);
                var delivery = productionDate;
                var address = $"{deliveryDay.Street}, Nro: {deliveryDay.Number}";
                var contractId = message.ContractId;
                var patientId = message.PatientId;
                var deliberyId = deliveryDay.Id;
                var labelId = Guid.NewGuid();

                var command = new CreateLabelCommand(
                    labelId,
                    productionDate,
                    expirationDate,
                    delivery,
                    "",
                    address,
                    contractId,
                    patientId,
                    deliberyId,
                    true
                ); 
                await mediator.Send(command, cancellationToken); 
            }
        }
    }
}
