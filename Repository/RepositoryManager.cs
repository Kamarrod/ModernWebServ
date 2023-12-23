using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IBlackListRepository> _blackListRepository;


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _blackListRepository = new Lazy<IBlackListRepository>(() => new BlackListRepository(repositoryContext));
        }

        public IBlackListRepository BlackListRepository => _blackListRepository.Value;

        public async Task<List<User>> GetUserAsync()
        {
            var values = 
            await _repositoryContext
            .Users
            .ToListAsync();

            return values;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var value =
            await _repositoryContext
            .Users
            .FirstOrDefaultAsync(x => x.Id.Equals(id.ToString()));

            return value;
        }

        public async Task<IEnumerable<MeetingUsers>> GetAllMeetingsUser()
        {
            var values = await _repositoryContext
                .MeetingUsers
                .ToListAsync();

            return values;
        }
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
