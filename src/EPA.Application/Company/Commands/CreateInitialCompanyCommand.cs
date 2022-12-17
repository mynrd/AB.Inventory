using AB.Inventory.Application.User.Models;
using MediatR;

namespace AB.Inventory.Application.Company.Commands
{
    public class CreateInitialCompanyCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public BasicUserInformation Admin { get; set; } = new BasicUserInformation();
    }

    public class CreateInitialCompanyCommandHandler : IRequestHandler<CreateInitialCompanyCommand>
    {
        public Task<Unit> Handle(CreateInitialCompanyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}