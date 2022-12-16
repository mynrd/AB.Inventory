using AB.Inventory.Application.Authentication.Models;
using MediatR;

namespace AB.Inventory.Application.Authentication.Commands
{
    public class LoginCommand : IRequest<UserTokenModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserTokenModel>
    {
        public Task<UserTokenModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}