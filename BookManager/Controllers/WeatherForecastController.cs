using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BookManager.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const string userId = "Admin";
        private const string pass = "Admin";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {

                var creadValue = header.ToString().Substring("Basic ".Length).Trim();
                var user = Encoding.UTF8.GetString(Convert.FromBase64String(creadValue));
                var userPass = user.Split(":");

                if (userPass[0].Trim() == userId && pass == userPass[1].Trim())
                {
                    var claimData = new[] { new Claim(ClaimTypes.Name, userPass[0]) };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789101112131415161718192021222324252627282930"));
                    var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var token = new JwtSecurityToken(
                        expires: DateTime.Now.AddHours(2),
                        claims: claimData,
                        signingCredentials: singIn
                        );
                    var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenresult);
                }
            }

            return Unauthorized();
        }
    }
}
