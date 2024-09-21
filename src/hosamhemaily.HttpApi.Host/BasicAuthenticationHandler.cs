using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using static IdentityModel.ClaimComparer;

namespace hosamhemaily
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IOptions<BasicAuthSettings> authSettings)
            : base(options, logger, encoder, clock)
        {
            _authSettings = authSettings.Value;

        }
        private readonly BasicAuthSettings _authSettings;


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
            {
                return AuthenticateResult.Fail("Authorization header is missing.");
            }
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[HeaderNames.Authorization]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                // Add your authentication logic here (e.g., check username and password against database)

                
                if (username != _authSettings .Username || password != _authSettings.Password)
                {
                    return AuthenticateResult.Fail("Invalid username or password.");
                }

                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid authorization header format.");
            }
        }
    }
}
