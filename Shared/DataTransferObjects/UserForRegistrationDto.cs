using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        public UserForRegistrationDto(string? firstName, string? lastName, string? userName, string? password, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        //public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }
    }
}