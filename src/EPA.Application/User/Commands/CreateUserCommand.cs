using AB.Inventory.Application.User.Models;
using MediatR;

namespace AB.Inventory.Application.User.Commands
{
    public class CreateUserCommand : BasicUserInformation, IRequest
    {
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}