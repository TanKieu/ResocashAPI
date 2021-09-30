using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ResocashAPI.Authentication;
using ResocashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;




namespace ResocashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ResocashContext _context;
        private IConfiguration _config; 

        public LoginController(ResocashContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet("Login/")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithGoogleOAuth([FromHeader] string authorization)
        {
            AuthenticationHeaderValue.TryParse(authorization, out var headerValue);
            var idToken = headerValue.Parameter;
            var defaultAPP = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("resocash-c9fb3-firebase-adminsdk-yg0s6-6c0f0d599f.json") });
            FirebaseToken decodeToken = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken.ToString());
             string uid = decodeToken.Uid;
            var user = _context.Users.FirstOrDefault(x => x.UserID == uid);
            if (user == null)
            {
                return Ok("Invalid user");
            }
            else
            {
                Authorization author = new Authorization(_config);
                var tokenString = author.GenerateJSONWebToken(user);
                return Ok(new { token = tokenString });
            }
        }
    }
}
