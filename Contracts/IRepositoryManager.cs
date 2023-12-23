using Entities.Models;
using Repository;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IBlackListRepository BlackListRepository { get; }
        Task<List<User>> GetUserAsync();
        Task<IEnumerable<MeetingUsers>> GetAllMeetingsUser();
        Task<User> GetUserByIdAsync(Guid id);
        Task SaveAsync();
    }
}