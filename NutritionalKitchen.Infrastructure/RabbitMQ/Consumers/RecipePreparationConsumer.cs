using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation;
using NutritionalKitchen.Integration.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.RabbitMQ.Consumers
{
    public class RecipePreparationConsumer(IMediator mediator) : IIntegrationMessageConsumer<RecipePreparation>
    {
        public async Task HandleAsync(RecipePreparation message, CancellationToken cancellationToken)
        {
            CreateRecipePreparationCommand command = new(
                message.Name,
                message.Description,
                message.CreatedAt,
                message.RecipeId
            );
            await mediator.Send(command, cancellationToken);
        }
    }
}
