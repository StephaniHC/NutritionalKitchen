using MediatR;
using NutritionalKitchen.Application.RecipePreparation.GetRecipe;
using NutritionalKitchen.Application.RecipePreparation.GetRecipePreparation;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenTask;
using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenTask.CreateKitchenTask
{
    [ExcludeFromCodeCoverage]
    public class CreateCommandHandler : IRequestHandler<CreateKitchenTaskCommand, Guid>
    {
        private readonly IKitchenTaskFactory _kitchenTaskFactory;
        private readonly IKitchenTaskRepository _kitchenTaskRepository;
        private readonly IPreparedFoodFactory _preparedFoodFactory;
        private readonly IPreparedFoodRepository _preparedFoodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateCommandHandler(
            IKitchenTaskFactory kitchenTaskFactory,
            IKitchenTaskRepository kitchenTaskRepository,
            IPreparedFoodFactory preparedFoodFactory,
            IPreparedFoodRepository preparedFoodRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            _kitchenTaskFactory = kitchenTaskFactory;
            _kitchenTaskRepository = kitchenTaskRepository;
            _preparedFoodFactory = preparedFoodFactory;
            _preparedFoodRepository = preparedFoodRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateKitchenTaskCommand request, CancellationToken cancellationToken)
        { 
            var kitchenTask = _kitchenTaskFactory.Create(
                request.kitchener,
                request.preparationDate
            );
            await _kitchenTaskRepository.AddAsync(kitchenTask);

            var recipePreparations = await _mediator.Send(new GetRecipePreparationByTodayQuery(), cancellationToken);

            foreach (var recipe in recipePreparations)
            { 
                var recipeDto = await _mediator.Send(new GetRecipeByIdQuery(recipe.RecipeId), cancellationToken);

                var preparedFood = _preparedFoodFactory.Create(
                    kitchenTask.Id,
                    recipe.Id,
                    request.preparationDate,
                    "En Proceso",
                    recipeDto?.Name ?? "", 
                    recipe.Detail,
                    recipe.PatientId
                );

                await _preparedFoodRepository.AddAsync(preparedFood);
            }


            await _unitOfWork.CommitBulkAsync(cancellationToken);

            return kitchenTask.Id;
        }
    }
}
