using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;
using Serilog;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userServiceFromBuilder)
        {
            _userService = userServiceFromBuilder;
        }

        /// <summary>
        /// Gets all users in the system.
        /// </summary>
        /// <returns>List of all users.</returns>
        [HttpGet("User/GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Gets a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">User Guid identifier.</param>
        /// <returns>The user if found, otherwise NotFound.</returns>
        [HttpGet("User/GetUserByID")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        /// <summary>
        /// Gets a specific user by their email address.
        /// </summary>
        [HttpGet("User/GetUserByEmail")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var userSignInAttempt = await _userService.GetUserByEmailAsync(email);
            if (userSignInAttempt == null) return NotFound();
            return Ok(userSignInAttempt);
        }
        /// <summary>
        /// Signs in a user with email and password.
        /// </summary>
        [HttpPost("User/SignIn")]
        public async Task<ActionResult<PUser>> SignInUser(SignIn signIn)
        {
            if (!await _userService.UserExistsAsync(signIn.Email))
            {
                return NotFound("Invalid email or password.");
            }
            try
            {
                User signInAttempt = await _userService.GetUserByEmailAsync(signIn.Email);
                if (await _userService.VerifyPasswordAsync(signInAttempt.Password, signIn.RawPassword))
                {
                    PUser signedInUser = new PUser(signInAttempt);
                    Log.Information($"User {signIn.Email} signed in successfully.");
                    return Ok(signedInUser);
                }
                else
                {
                    return Unauthorized("Invalid email or password.");
                }
            }
            catch (Exception e)
            {
                return NotFound("Invalid email or password.");
            }
        }
    }
}
