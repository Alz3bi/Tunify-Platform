using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IUser
    {
        // Create a new user
        Task<User> CreateUserAsync(User user);

        // Get a user by ID
        Task<User> GetUserByIdAsync(int userId);

        // Get all users
        Task<IEnumerable<User>> GetAllUsersAsync();

        // Get a user by username
        Task<User> GetUserByUsernameAsync(string username);

        // Update an existing user
        Task<User> UpdateUserAsync(User user);

        // Delete a user by ID
        Task<bool> DeleteUserAsync(int userId);
    }
}
