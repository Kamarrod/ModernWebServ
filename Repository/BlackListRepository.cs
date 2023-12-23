using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BlackListRepository : RepositoryBase<BlackList>, IBlackListRepository 
    {
        public BlackListRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void Create(BlackList blackList)
        {
            Create(blackList);
        }
    }
}
