using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalKitchen.Application.RecipePreparation.CreateRecipe;
using NutritionalKitchen.Integration.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.RabbitMQ.Consumers
{
    public class RecipeConsumer(IMediator mediator) : IIntegrationMessageConsumer<RecipePreparation>
    {
        public async Task HandleAsync(RecipePreparation message, CancellationToken cancellationToken)
        {
            CreateRecipeCommand command = new(
                message.RecipeId,
                message.Name,
                message.Description
            );
            await mediator.Send(command, cancellationToken);
        }
    }
}
