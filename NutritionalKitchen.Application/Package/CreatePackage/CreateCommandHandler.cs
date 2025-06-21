using MediatR; 
using NutritionalKitchen.Domain.Abstractions; 
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.CreatePackage
{
    public class CreateCommandHandler : IRequestHandler<CreatePackageCommand, Guid>
    {
        private readonly IPackageFactory _packageFactory;
        private readonly IPackageRepository _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            IPackageFactory packageFactory,
            IPackageRepository packageRepository,
            IUnitOfWork unitOfWork)
        {
            _packageFactory = packageFactory;
            _packageRepository = packageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var label = _packageFactory.Create(request.status, request.labelId);

            await _packageRepository.AddAsync(label);

            await _unitOfWork.CommitAsync(cancellationToken);

            return label.Id; 
        }
    }
}
