using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IdentityAccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<UserDTO> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginDto.Username);
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
            }
            return null;
        }

        public async Task<bool> Logout()
        {
            if (_signInManager.IsSignedIn(_signInManager.Context.User))
                {
                await _signInManager.SignOutAsync();
                return true;
            }
            return false;
        }

        public async Task<UserDTO> Register(RegisterDto registerDto)
        {
            var user = new ApplicationUser { UserName = registerDto.Username, Email = registerDto.Email };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
            }
            return null;
        }
    }
}
