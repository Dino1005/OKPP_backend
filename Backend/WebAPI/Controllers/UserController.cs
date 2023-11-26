using Firebase.Auth;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.Authentication;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FirebaseAuthClient client = new FirebaseAuthClient(FirebaseConfig.AuthConfig);

        [Authorize(Roles = "admin")]
        [HttpPut("update-role/{userId}/{role}")]
        public async Task<IActionResult> UpdateUserRoleAsync(string userId, string role)
        {
            try
            {
                var claims = new Dictionary<string, object>(){ { "role", role } };
                await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userId, claims);
            }
            catch (FirebaseAdmin.Auth.FirebaseAuthException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Role updated!");
        }

        [HttpPost("/login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginModel model)
        {
            try
            {
                var userCredentials = await client.SignInWithEmailAndPasswordAsync(model.Email, model.Password);

                if (userCredentials != null)
                {
                    UserRecord user = await FirebaseAuth.DefaultInstance.GetUserAsync(userCredentials.User.Uid);

                    var result = new UserCredentials()
                    {
                        AccessToken = userCredentials.User.Credential.IdToken,
                        ExpiresIn = userCredentials.User.Credential.ExpiresIn.ToString(),
                        UserId = userCredentials.User.Uid,
                        Role = user.CustomClaims["role"].ToString()
                    };

                    return Ok(result);
                }
            }
            catch (Firebase.Auth.FirebaseAuthException ex)
            {
                return BadRequest(FirebaseHelper.HandleFirebaseError(ex));
            }

            return BadRequest("Failed to login.");
        }

        [HttpPost("/register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterModel model)
        {
            try
            {
                var userCredentials = await client.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password);

                if (userCredentials != null)
                {
                    var claims = new Dictionary<string, object>()
                    {
                        { "role", "user" },
                    };
                    await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(userCredentials.User.Uid, claims);

                    return Ok("User successfully registered.");
                }
            }
            catch (Firebase.Auth.FirebaseAuthException ex)
            {
                return BadRequest(FirebaseHelper.HandleFirebaseError(ex));
            }

            return BadRequest("Failed to login.");
        }
    }

    public class UserCredentials
    {
        public string? AccessToken { get; set; }

        public string? ExpiresIn { get; set; }

        public string? UserId { get; set; }

        public string? Role {  get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Email { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Email { get; set; }
    }
}