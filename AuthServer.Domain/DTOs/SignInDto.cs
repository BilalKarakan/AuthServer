namespace AuthServer.Domain.DTOs;

public class SignInDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
