using GoogleAuth.Api.Models;
using GoogleAuth.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuth.Api.Controllers;

[ApiController, Produces(contentType: "application/json")]
[Route(template: "api/[controller]/v1")]
public class AuthController(IGoogleAuthenticationService googleAuthenticationService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("token-validation")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ValidateTokenAsync([FromBody] TokenValidationModel model)
    {
        var isValidToken = await googleAuthenticationService.ValidateJsonWebTokenAsync(model.Token);
        return isValidToken ? NoContent() : BadRequest(error: "The given token is not valid.");
    }
}
