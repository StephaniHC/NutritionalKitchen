using MediatR;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.PreparedFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.PreparedFood.UpdatePreparedFood
{
    public class UpdateCommandHandler : IRequestHandler<UpdatePreparedFoodCommand, Unit>
    {
        private readonly IPreparedFoodRepository _preparedFoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommandHandler(
            IPreparedFoodRepository preparedFoodRepository,
            IUnitOfWork unitOfWork)
        {
            _preparedFoodRepository = preparedFoodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePreparedFoodCommand request, CancellationToken cancellationToken)
        { 
            var preparedFoods = await _preparedFoodRepository
                .GetByPreparationDateAsync(request.RecipePreparationDate);

            foreach (var item in preparedFoods)
            {
                item.UpdateStatus("Finalizado");
                await _preparedFoodRepository.UpdateAsync(item);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
