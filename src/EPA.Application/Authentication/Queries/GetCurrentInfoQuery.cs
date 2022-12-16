using Blazored.LocalStorage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Inventory.Application.Authentication.Queries
{
    public class GetCurrentInfoQuery : IRequest<CurrentInfoDto>
    {
    }

    public class CurrentInfoDto
    {
        public int Id { get; set; }
        public string UserTitle { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string ServerName { get; set; }
    }

    public class GetCurrentInfoQueryHandler : IRequestHandler<GetCurrentInfoQuery, CurrentInfoDto>
    {
        private readonly ILocalStorageService _localStorageService;

        public GetCurrentInfoQueryHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<CurrentInfoDto> Handle(GetCurrentInfoQuery request, CancellationToken cancellationToken)
        {
            return await _localStorageService.GetItemAsync<CurrentInfoDto>("info");
        }
    }
}
