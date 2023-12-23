using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class TokenBlackListService
    {
        private readonly IRepositoryManager _repositoryManager;
        public TokenBlackListService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        
    }
}
