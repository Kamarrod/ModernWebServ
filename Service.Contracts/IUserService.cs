using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<ReturnUserDto>> GetAllUsersAsync();
        Task<ReturnUserDto> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(Guid id, UserForUpdateDto userForUpdateDto, bool trackChanges);
    }
}
