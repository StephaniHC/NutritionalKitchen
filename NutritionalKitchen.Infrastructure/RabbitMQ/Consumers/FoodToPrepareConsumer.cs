using Joseco.Communication.External.Contracts.Services;
using MediatR; 
using NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation; 
using NutritionalKitchen.Integration.PreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infrastructure.RabbitMQ.Consumers
{
    public class FoodToPrepareConsumer(IMediator mediator) : IIntegrationMessageConsumer<PreparedFood>
    {
        public async Task HandleAsync(PreparedFood message, CancellationToken cancellationToken)

        {
            foreach (var mealTimes in message.MealTimes)
            {
                var recipeId = mealTimes.RecipeId;
                var detail = $"{message.Name}, {message.Description}. Meta: {message.Goal}";
                var mealTime = mealTimes.Type;
                var preparationDate = mealTimes.Date;
                var patientId = message.PatientId;

                var command = new CreateRecipePreparationCommand(
                    recipeId,
                    detail,
                    mealTime,
                    preparationDate,
                    patientId
                );
                await mediator.Send(command, cancellationToken);
            }
        }
    }
}
