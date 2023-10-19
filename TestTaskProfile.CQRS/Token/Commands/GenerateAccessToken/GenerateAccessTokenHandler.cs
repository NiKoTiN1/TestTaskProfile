using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace TestTaskProfile.CQRS.Token.Commands.GenerateAccessToken
{
    public class GenerateAccessTokenHandler : IRequestHandler<GenerateAccessTokenCommand, string>
    {
        private readonly IConfiguration _configuration;

        public GenerateAccessTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Handle(GenerateAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", request.User.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(_configuration["Authentication:LIFETIME"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:KEY"])), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["Authentication:AUDIENCE"],
                Issuer = _configuration["Authentication:ISSUER"],
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return await Task.FromResult(tokenHandler.WriteToken(token));
            }
            catch
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
