using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System.Runtime.CompilerServices;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repositoryManager,
                              IMapper mapper,
                              UserManager<User> userManager,
                              IConfiguration configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(mapper, userManager,
            configuration));

            _userService = new Lazy<IUserService>(() =>
            new UserService(repositoryManager, mapper));

        }
        public IAuthenticationService AuthenticationService =>
        _authenticationService.Value;

        public IUserService UserService => _userService.Value;

       
    }
}