using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.JwtSigningCredentials.Interfaces;

using Inspecoes.Data;
using Inspecoes.Extensions;
using Inspecoes.Models;
using Inspecoes.Interfaces;

namespace Inspecoes.Services
{
    public class AuthService
    {
        public readonly SignInManager<IdentityUser> SignInManager;
        public readonly UserManager<IdentityUser> UserManager;
        private readonly AppSettings _appSettingsValue;
       
        private readonly AppIdentityDbContext _context;//
        private readonly IJsonWebKeySetService _jwksService;
        private readonly IUser _aspNetUser;

        public AuthService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,
          
            AppIdentityDbContext context,//
            IJsonWebKeySetService jwksService,
            IUser aspNetUser)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _appSettingsValue = appSettings.Value;
         
            _jwksService = jwksService;
            _aspNetUser = aspNetUser;
            _context = context;
        }

        public async Task<LoginResponseViewModel> GerarJwt(string userName)
        {
            IdentityUser user;
            user = await UserManager.FindByNameAsync(userName);// FindByEmailAsync(email);
            var claims = await UserManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            var encodedToken = CodificarToken(identityClaims);

            var refreshToken = await GerarRefreshToken(userName);

            return ObterRespostaToken(encodedToken, user, claims, refreshToken);
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuario(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var currentIssuer = $"{_aspNetUser.ObterHttpContext().Request.Scheme}://{_aspNetUser.ObterHttpContext().Request.Host}";
            var key = Encoding.ASCII.GetBytes(_appSettingsValue.Secret); 
            var keyJwks = _jwksService.GetCurrent();

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettingsValue.Emissor, // currentIssuer,
                Audience = _appSettingsValue.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettingsValue.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // SigningCredentials = keyJwks
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        private LoginResponseViewModel ObterRespostaToken(string encodedToken, IdentityUser user, 
             IEnumerable<Claim> claims, RefreshToken refreshToken) 
        {
            return new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = TimeSpan.FromHours(_appSettingsValue.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);


       // xttps://desenvolvedor.io/curso/asp-net-core-enterprise-applications/melhorias-e-novas-tecnologias/refresh-token-na-api-de-identidade
        private async Task<RefreshToken> GerarRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                Username = userName,
                ExpirationDate = DateTime.UtcNow.AddHours(_appSettingsValue.RefreshTokenExpiration)
            };

            _context.RefreshTokens.RemoveRange(_context.RefreshTokens.Where(u => u.Username == userName));
            await _context.RefreshTokens.AddAsync(refreshToken);

            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<RefreshToken> ObterRefreshToken(Guid refreshToken)
        {
            var token = await _context.RefreshTokens.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Token == refreshToken);

            return token != null && token.ExpirationDate.ToLocalTime() > DateTime.Now
                ? token
                : null;
        }
        

    }
}