using MediatR; 
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.RecipePreparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.RecipePreparation.CreateRecipe
{
    public class CreateCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
    {
        private readonly IRecipeFactory _recipeFactory;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            IRecipeFactory recipeFactory,
            IRecipeRepository recipeRepository,
            IUnitOfWork unitOfWork)
        {
            _recipeFactory = recipeFactory;
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _recipeFactory.Create(request.id, request.name, request.description);

            await _recipeRepository.AddAsync(recipe);

            await _unitOfWork.CommitAsync(cancellationToken);

            return recipe.Id;
        }
    }
}
