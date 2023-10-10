using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Proyecto.Middleware
{
    /// <summary>
    /// Middleware para validar token Jwt
    /// El token debe llegar en el header en forma: "Authorization: Bearer token"
    /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// constructor de la clase middleware
        /// </summary>
        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        /// <summary>
        /// Valida el token emitido con llaves de configuración en appSetings que comparte con SecurityApi.
        /// </summary>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if ((token != null) && (ValidateToken(token)))
            {
                httpContext.Items["UserId"] = _configuration["SecurityAPI:JWT_USER"];
            } 

            await _next(httpContext);
        }

        private bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["SecurityAPI:JWT_SECRET_KEY"] ?? "");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["SecurityAPI:JWT_ISSUER_TOKEN"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["SecurityAPI:JWT_AUDIENCE_TOKEN"],
                    ClockSkew = TimeSpan.Zero,
                }, out SecurityToken securityToken);

                var jwtToken = (JwtSecurityToken)securityToken;
                var isOk = jwtToken.Claims.First(t => t.Type == "unique_name").Value == _configuration["SecurityAPI:JWT_USER"];

                return isOk;
            }
            catch
            {
                return false;
            }
        }

    }
}
