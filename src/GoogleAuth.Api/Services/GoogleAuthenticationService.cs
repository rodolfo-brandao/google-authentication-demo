using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace GoogleAuth.Api.Services;

public class GoogleAuthenticationService : IGoogleAuthenticationService
{
    public async Task<bool> ValidateJsonWebTokenAsync(string token)
    {
        try
        {
            var payload = await ValidateAsync(token, new ValidationSettings
            {
                Audience = ["<YOUR_CLIENT_ID_HERE>"]
            });

            // (optional) If the e-mail used to issue the token is hosted by a specific domain,
            // an additional layer of validation is to verify the domain.
            const string allowedHostedDomain = "google.com";
            if (!string.IsNullOrWhiteSpace(payload.HostedDomain))
            {
                return payload.HostedDomain.Equals(allowedHostedDomain);
            }

            return true;
        }
        catch (InvalidJwtException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
