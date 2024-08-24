using Microsoft.Extensions.Options;

namespace BookStore.Authentication
{
    public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";

        private readonly IConfiguration configuration = configuration;

        public void Configure(JwtOptions options)
        {
            this.configuration.GetSection(SectionName).Bind(options);
        }
    }
}
