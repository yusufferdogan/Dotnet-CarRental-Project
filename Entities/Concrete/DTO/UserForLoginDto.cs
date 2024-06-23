using Core.Entities;

namespace Entities.Concrete.DTO;

public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}