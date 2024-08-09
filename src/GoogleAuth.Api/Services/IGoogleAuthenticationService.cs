namespace GoogleAuth.Api.Services;

public interface IGoogleAuthenticationService
{
    Task<bool> ValidateJsonWebTokenAsync(string token);
}
