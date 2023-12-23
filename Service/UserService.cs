using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService
    {
        public readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReturnUserDto>> GetAllUsersAsync()
        {
            var users = await _repositoryManager.GetUserAsync();
            var usersDto = _mapper.Map<List<ReturnUserDto>>(users);
            
            for(int i = 0; i < usersDto.Count; i++)
            {
                if (usersDto[i].Id.ToString() == "42dd314f-494c-4a68-bd7b-23568e710ad2")
                    usersDto[i] = new ReturnUserDto
                    {
                        Id = usersDto[i].Id,
                        UserName = usersDto[i].UserName,
                        LastName = usersDto[i].LastName,
                        FirstName = usersDto[i].FirstName,
                        PasswordHash = usersDto[i].PasswordHash,
                        Role = "Admin"
                    };
            }

            return usersDto;
        }

        public async Task<ReturnUserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _repositoryManager.GetUserByIdAsync(id);

            var userDto = _mapper.Map<ReturnUserDto>(user);
            if (userDto.Id.ToString() == "42dd314f-494c-4a68-bd7b-23568e710ad2") ;
            var retDto = new ReturnUserDto
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                LastName = userDto.LastName,
                FirstName = userDto.FirstName,
                PasswordHash = userDto.PasswordHash,           
                Role = "Admin"
            };
            return retDto;
        }

        public async Task UpdateUserAsync(Guid id, UserForUpdateDto userForUpdateDto, bool trackChanges)
        {
            var user = await _repositoryManager.GetUserByIdAsync(id);
            if (user is null)
                throw new NullReferenceException();


            _mapper.Map(userForUpdateDto, user);
            await _repositoryManager.SaveAsync();
        }

    }
}
