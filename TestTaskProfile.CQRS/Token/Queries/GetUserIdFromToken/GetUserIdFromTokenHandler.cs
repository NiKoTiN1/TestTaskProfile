using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TestTaskProfile.CQRS.Token.Queries.GetUserIdFromToken
{
    public class GetUserIdFromTokenHandler : IRequestHandler<GetUserIdFromTokenQuery, Guid>
    {
        private readonly IConfiguration _configuration;

        public GetUserIdFromTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Guid> Handle(GetUserIdFromTokenQuery request, CancellationToken cancellationToken)
        {
            var tokenValidationParamters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration["Authentication:ISSUER"],
                ValidateAudience = true,
                ValidAudience = _configuration["Authentication:AUDIENCE"],
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:KEY"])),
                ValidateIssuerSigningKey = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(request.accessToken, tokenValidationParamters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token!");
            }

            var userId = principal.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new SecurityTokenException("Missing claim: UserId!");
            }

            return await Task.FromResult(Guid.Parse(userId));
        }
    }
}
