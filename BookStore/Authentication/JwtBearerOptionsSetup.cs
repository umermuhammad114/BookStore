using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Authentication
{
    public class JwtBearerOptionsSetup(IOptions<JwtOptions> options) : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtOptions options = options.Value;

        public void Configure(JwtBearerOptions bearerOptions)
        {
            bearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = this.options.Issuer,
                ValidAudience = this.options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.options.SecretKey))
            };
        }

        public void Configure(string? name, JwtBearerOptions bearerOptions)
        {
            this.Configure(bearerOptions);
        }
    }
}
