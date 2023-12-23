using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ReturnUserDto//(Guid Id, string UserName,  string PasswordHash, string FirstName, string LastName, string? Role = "User" );
    {
        public Guid Id { get; init; }
        public string UserName { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Role { get; init; } = "User";
        public string PasswordHash { get; init; }

    }
}
