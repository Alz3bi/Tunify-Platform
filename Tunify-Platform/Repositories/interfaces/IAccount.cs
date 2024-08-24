using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IAccount
    {
        // Register a new user
        Task<UserDTO> Register(RegisterDto registerDto);
        // Login a user
        Task<UserDTO> Login(LoginDto loginDto);
        // Logout a user
        Task<bool> Logout();

    }
}
