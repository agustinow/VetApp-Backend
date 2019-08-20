using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VetApi.Models;

namespace VetApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserManagementService _service;
        private readonly TokenManagement _tokenManagement;

        public AuthenticationService(IUserManagementService service, IOptions<TokenManagement> tokenManagement)
        {
            _service = service;
            _tokenManagement = tokenManagement.Value;
        }

        public bool IsAuthenticated(TokenRequest request, out string token)
        {
            token = string.Empty;
            var usr = _service.IsValidUser(request.Username, request.Password);
            var role = new Claim(ClaimTypes.Role, "owner");
            if (usr.Equals("null")) return false;
            if (usr.Equals("vet"))
            {
                role = new Claim(ClaimTypes.Role, "vet");
            }
            else if (usr.Equals("admin"))
            {
                role = new Claim(ClaimTypes.Role, "admin");
            }

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                role
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }

    }

    public interface IAuthenticationService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}
