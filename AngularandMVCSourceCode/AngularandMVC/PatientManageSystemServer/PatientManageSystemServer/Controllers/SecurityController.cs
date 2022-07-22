using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PatientManageSystemServer.Controllers
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
    }
    public class Token
    {
        public string value { get; set; }
    }
    public class SecurityController : Controller
    {
        public IActionResult Login([FromBody] User obj)
        {
            // if existing in the DB
            if ((obj.name == "Shiv") && (obj.password=="Pass")) // this call will be to th DB
            {
                string tk = GenerateJSONWebToken(obj.name);
                Token objt = new Token();
                objt.value = tk;
                return Ok(objt);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Not alowed");
            }
        }
        private string GenerateJSONWebToken(string username)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Shiv@123333Shiv@12333"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("Issuer", "Shiv"),
                new Claim("Admin","true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, username)
            };

            var token = new JwtSecurityToken("Shiv",
              "Shiv",
              claims,
              expires: DateTime.Now.AddSeconds(40),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
