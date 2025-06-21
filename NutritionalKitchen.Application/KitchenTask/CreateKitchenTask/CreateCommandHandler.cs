using MediatR; 
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.KitchenTask; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenTask.CreateKitchenTask
{
    public class CreateCommandHandler : IRequestHandler<CreateKitchenTaskCommand, Guid>
    {
        private readonly IKitchenTaskFactory _kitchenTaskFactory;
        private readonly IKitchenTaskRepository _kitchenTaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            IKitchenTaskFactory kitchenTaskFactory,
            IKitchenTaskRepository kitchenTaskRepository,
            IUnitOfWork unitOfWork)
        {
            _kitchenTaskFactory = kitchenTaskFactory;
            _kitchenTaskRepository = kitchenTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateKitchenTaskCommand request, CancellationToken cancellationToken)
        {
            var kitchenTask = _kitchenTaskFactory.Create(request.description, request.status, request.kitchener, request.preparationDate);

            await _kitchenTaskRepository.AddAsync(kitchenTask);

            await _unitOfWork.CommitAsync(cancellationToken);

            return kitchenTask.Id;  
        } 
    }
}
