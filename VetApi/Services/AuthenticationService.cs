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

        public bool IsAuthenticated(TokenRequest request, out TokenResponse response)
        {
            response = new TokenResponse();
            var usr = _service.IsValidUser(request.Username, request.Password, out bool passwordRight);
            response.Type = usr;
            if (passwordRight)
            {
                var role = new Claim(ClaimTypes.Role, "null");
                switch (usr)
                {
                    case "vet":
                        {
                            role = new Claim(ClaimTypes.Role, "vet");
                            break;
                        }
                    case "owner":
                        {
                            role = new Claim(ClaimTypes.Role, "owner");
                            break;
                        }
                    case "admin":
                        {
                            role = new Claim(ClaimTypes.Role, "admin");
                            break;
                        }
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
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return true;
            }
            else
            {
                if(usr == "null")
                {
                    response.Token = "Invalid Username";
                }
                else
                {
                    response.Token = "Invalid Password";
                }
                return false;
            }
        }

    }

    public interface IAuthenticationService
    {
        bool IsAuthenticated(TokenRequest request, out TokenResponse token);
    }
}
