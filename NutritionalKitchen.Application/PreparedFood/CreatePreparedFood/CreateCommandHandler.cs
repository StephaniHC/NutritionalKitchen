using MediatR;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.PreparedFood.CreatePreparedFood
{
    public class CreateCommandHandler : IRequestHandler<CreatePreparedFoodCommand, Guid>
    {
        private readonly IPreparedFoodFactory _preparedFoodFactory;
        private readonly IPreparedFoodRepository _preparedFoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            IPreparedFoodFactory preparedFoodFactory,
            IPreparedFoodRepository preparedFoodRepository,
            IUnitOfWork unitOfWork)
        {
            _preparedFoodFactory = preparedFoodFactory;
            _preparedFoodRepository = preparedFoodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePreparedFoodCommand request, CancellationToken cancellationToken)
        {
            var preparedFood = _preparedFoodFactory.Create(request.idKitchenTask, request.idRecipePreparation, request.recipePreparationDate, request.status, request.recipe, request.detail, request.patientId);

            await _preparedFoodRepository.AddAsync(preparedFood);

            await _unitOfWork.CommitAsync(cancellationToken);

            return preparedFood.Id;
        }
    }
}
