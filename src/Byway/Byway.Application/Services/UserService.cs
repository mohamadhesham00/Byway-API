using Byway.Application.Common.Models;
using Byway.Application.DTOs.User;
using Byway.Application.Interfaces;
using Byway.Domain.Entities;
using Byway.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Byway.Application.Services
{
    public class UserService(UserManager<AppUser> userManager, IJwtTokenGenerator jwtTokenGenerator) : IUserService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        public async Task<Result<string>> LoginAsync(LoginDto dto)
        {
            AppUser? user = await _userManager.FindByNameAsync(dto.UserName);
            bool isEmail = false;

            var isValid = user == null ? false : await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isValid)
            {
                return Result<string>.Failure($"Invalid {(isEmail ? "Email" : "Username")} or Password ", 401);
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);
            return Result<string>.Success(token);


        }

        public async Task<Result<string>> RegisterAsync(CreateUserDto dto)
        {
            // Check username
            var existingUser = await _userManager.FindByNameAsync(dto.UserName);
            if (existingUser != null)
            {
                return Result<string>.Failure("This username is not available. Please try a different one.", 409);
            }

            // Check email
            existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return Result<string>.Failure("This email is not available. Please try a different one.", 409);
            }

            // Create new user
            var newUser = new AppUser
            (
                dto.FirstName,
                dto.LastName,
                dto.UserName,
                dto.Email
            );

            // Create user with password
            var createResult = await _userManager.CreateAsync(newUser, dto.Password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join("; ", createResult.Errors.Select(e => e.Description));
                return Result<string>.Failure(errors, 400);
            }

            // Assign default role
            var roleResult = await _userManager.AddToRoleAsync(newUser, UserRole.User.ToString());
            if (!roleResult.Succeeded)
            {
                var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                return Result<string>.Failure(errors, 400);
            }

            // Generate JWT
            var roles = await _userManager.GetRolesAsync(newUser);
            var token = _jwtTokenGenerator.GenerateToken(newUser, roles);

            return Result<string>.Success(token);
        }

    }
}
