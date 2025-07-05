using MediatR;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Label;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.UpdateLabel
{
    [ExcludeFromCodeCoverage]
    public class UpdateCommandHandler : IRequestHandler<UpdateLabelCommand, Unit>
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommandHandler(
            ILabelRepository labelRepository,
            IUnitOfWork unitOfWork)
        {
            _labelRepository = labelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateLabelCommand request, CancellationToken cancellationToken)
        {
            var label = await _labelRepository.GetByIdAsync(request.DeliberyId);

            if (label == null)
            {
                throw new Exception($"Label with ID {request.DeliberyId} not found");
            }

            label.Update(  
                request.Address
            );

            await _labelRepository.UpdateAsync(label);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        } 
    }
}
