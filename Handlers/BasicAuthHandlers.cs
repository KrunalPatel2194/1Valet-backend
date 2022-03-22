using Backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Backend.Handlers
{
    public class BasicAuthHandlers : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly deviceapidbContext _context;
        public BasicAuthHandlers(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            ISystemClock clock
            //deviceapidbContext context
            )
            : base(options, loggerFactory, encoder, clock)
        {
            //_context = context;
        }

        //protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        //{
        //    throw new NotImplementedException();
        //}
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found");
            try
            {
                var authenticationHeadeValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

            var bytes = Convert.FromBase64String(authenticationHeadeValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                //int deviceId = Int32.Parse(credentials[0]);
                //string deviceName = credentials[1];
                string emailAddress = credentials[0];
                string password = credentials[1];
                //Device device = _context.Devices.Where(device => device.DeviceId == deviceId && device.DeviceName == deviceName).FirstOrDefault();
                if (emailAddress != "krun2102@gmail.com" && password == "Kruxyz12")
                {
                    AuthenticateResult.Fail("Invalid credentials");
                }
                else
                {
                    //var claims = new[] { new Claim( new BinaryWriter(ClaimTypes.Name), device.DeviceId ) };
                    var claim = new[] { new Claim(ClaimTypes.Name, emailAddress) };
                    var identity = new ClaimsIdentity(claim, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                     return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception ex)
            {
                // throw new NotImplementedException();
                return AuthenticateResult.Fail("Error has occured");
            }

            // throw new NotImplementedException();

            return AuthenticateResult.Fail("USer not authorized");

        }
    }
}
