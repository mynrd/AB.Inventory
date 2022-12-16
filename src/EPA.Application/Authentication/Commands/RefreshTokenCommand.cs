using AB.Inventory.Application.Authentication.Models;
using MediatR;

namespace AB.Inventory.Application.Authentication.Commands
{
    public class RefreshTokenCommand : IRequest<UserTokenModel>
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
    }

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, UserTokenModel>
    {
        public Task<UserTokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}