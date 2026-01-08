using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tenants.Commands;

public class CreateTenantCommand
{
    public string Name { get; set; }
}

public class CreateTenantCommandHandler // : IRequestHandler
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateTenantCommandHandler(ITenantRepository tenantRepository, IUnitOfWork unitOfWork)
    {
        _tenantRepository = tenantRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = new Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        
        _tenantRepository.Add(tenant);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return tenant.Id;
    }
}

public class CreateTenantCommandValidator // : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        
    }
}