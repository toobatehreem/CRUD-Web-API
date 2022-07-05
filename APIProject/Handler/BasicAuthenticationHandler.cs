using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System;
using System.Text;
using APIProject.Data;
using System.Linq;
using System.Security.Claims;

namespace APIProject.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ApplicationDbContext _context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ApplicationDbContext applicationDbContext)
            :
            base(options, logger, encoder, clock)
        {
            _context = applicationDbContext;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No header found");
            }
            else
            {
                var _headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(_headerValue.Parameter);
                string credentials = Encoding.UTF8.GetString(bytes);
                if (!string.IsNullOrEmpty(credentials))
                {
                    string[] array = credentials.Split(':');
                    string username = array[0];
                    string password = array[1];

                    var user = this._context.Users.FirstOrDefault(item => item.Name == username && item.Password == password);
                    if (user == null)
                    {
                        return AuthenticateResult.Fail("Unauthorized");
                    }
                    else
                    {
                        var claim = new[] { new Claim(ClaimTypes.Name, username) };
                        var identity = new ClaimsIdentity(claim, Scheme.Name);
                        var principal = new ClaimsPrincipal(identity);
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);

                        return AuthenticateResult.Success(ticket);
                    }
                }
                else
                {
                    return AuthenticateResult.Fail("Unauthorized");
                }

            }

        }
    }
}
