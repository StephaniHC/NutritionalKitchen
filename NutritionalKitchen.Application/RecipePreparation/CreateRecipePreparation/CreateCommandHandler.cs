using MediatR;
using NutritionalKitchen.Domain.Abstractions; 
using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.CreateRecipePreparation
{
    public class CreateCommandHandler : IRequestHandler<CreateRecipePreparationCommand, Guid>
    {
        private readonly IRecipePreparationFactory _recipePreparationFactory;
        private readonly IRecipePreparationRepository _recipePreparationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            IRecipePreparationFactory recipePreparationFactory,
            IRecipePreparationRepository recipePreparationRepository,
            IUnitOfWork unitOfWork)
        {
            _recipePreparationFactory = recipePreparationFactory;
            _recipePreparationRepository = recipePreparationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateRecipePreparationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var preparedFood = _recipePreparationFactory.Create(
                    request.id,
                    request.recipeId,
                    request.detail,
                    request.mealTime,
                    request.preparationDate,
                    request.patientId
                );

                await _recipePreparationRepository.AddAsync(preparedFood);
                await _unitOfWork.CommitBulkAsync(cancellationToken);

                Console.WriteLine($"[Handler] Creado RecipePreparation: {preparedFood.Id}");

                return preparedFood.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Handler][ERROR] {ex.Message}");
                throw;
            }
        }

    }
}
