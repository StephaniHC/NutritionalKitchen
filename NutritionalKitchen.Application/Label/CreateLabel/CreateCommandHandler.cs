using MediatR; 
using NutritionalKitchen.Domain.Abstractions; 
using NutritionalKitchen.Domain.Label;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.CreateLabel
{
    public class CreateCommandHandler : IRequestHandler<CreateLabelCommand, Guid>
    {
        private readonly ILabelFactory _labelFactory;
        private readonly ILabelRepository _labelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            ILabelFactory labelFactory,
            ILabelRepository labelRepository,
            IUnitOfWork unitOfWork)
        {
            _labelFactory = labelFactory;
            _labelRepository = labelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            var label = _labelFactory.Create(
                request.id, 
                request.productionDate, 
                request.expirationDate, 
                request.deliberyDate, 
                request.detail, 
                request.address, 
                request.contractId, 
                request.patientId, 
                request.deliberyId, 
                true
                );
              
            await _labelRepository.AddAsync(label);

            await _unitOfWork.CommitBulkAsync(cancellationToken); 

            return label.Id;
        }
    }
}
