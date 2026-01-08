using MediatR;
using FluentValidation;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tenants.Commands;

public class CreateTenantCommand : IRequest<Guid>
{
    public string Name { get; set; }
}

public class CreateTenantCommandHandler(ITenantRepository tenantRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTenantCommand, Guid>
{
    public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = new Tenant
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };
        
        tenantRepository.Add(tenant);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return tenant.Id;
    }
}

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Tenant Name is required")
            .MaximumLength(100)
            .WithMessage("Tenant Name cannot exceed 100 characters");
    }
}