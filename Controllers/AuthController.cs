
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Inspecoes.Models;
using Inspecoes.Extensions;
using Inspecoes.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Inspecoes.Services;

namespace Inspecoes.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class AuthController : MainController
    {
        private readonly AppSettings _appSettings;
        private readonly AuthService _authService;

        public AuthController(INotifier notifier, IUser aspNetUser,
                              IOptions<AppSettings> appSettings,
                              AuthService authService
            ) : base(notifier, aspNetUser)
        {
            _appSettings = appSettings.Value;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult> Registrar(CreateUserViewModel registerUser)
        {
           if (!ModelState.IsValid) return CustomResponse(ModelState);

           var user = new IdentityUser
           { UserName = registerUser.UserName, // registerUser.Email
             Email = registerUser.Email,
             EmailConfirmed = true
           };

            var result = await _authService.UserManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _authService.SignInManager.SignInAsync(user, isPersistent: false); // 
                return CustomResponse(registerUser);
            }
            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }
            return CustomResponse(registerUser);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid ) return CustomResponse(ModelState);
            var result = await _authService.SignInManager.PasswordSignInAsync(loginUser.UserName,
                loginUser.Password, false, true);

            if (result.Succeeded)
            {
                //Notificar
                return CustomResponse(await _authService.GerarJwt(loginUser.UserName)); // (loginUser);
            }
            if (result.IsLockedOut)
            {
                NotifyError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }
            NotifyError("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                NotifyError("Refresh Token Inválido");
                return CustomResponse();
            }

            var token = await _authService.ObterRefreshToken(Guid.Parse(refreshToken));
            if (token is null)
            {
                NotifyError("Refresh Token expirado");
                return CustomResponse();
            }

            return CustomResponse(await _authService.GerarJwt(token.Username));

        }
    }
}
