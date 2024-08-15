using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop4UAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userRepository.GetAllUsers();
            if (result.ToList().Count == 0)
                return NotFound(new { Message = "No Users Have Been Found!" });
            else
                return Ok(result);
        }

        [HttpGet("{id:int}/get-one-user")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id == null)
                return BadRequest(new { Message = "No ID Has Been Entered!" });
            var result = await _userRepository.GetOneUser(id);
            return Ok(result);



        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            try
            {
                if (user.Username == "" || user.Email == "")
                    return BadRequest(new { Message = "No User Has Been Entered!" });

                var checkUsernameExist = await _userRepository.CheckUsernameExist(user.Username);
                if (checkUsernameExist)
                    return BadRequest(new { Message = "This Username Already Exist!" });

                var checkEmailExist = await _userRepository.ChechEmailExist(user.Email);
                if (checkEmailExist)
                    return BadRequest(new { Message = "This Email Already Exist!" });


                var result = _userRepository.CreateUser(user);
                return Ok(new { Message = "User Added!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {

               // var checkUsername = await _userRepository.CheckUsernameExist(user.Username);

                //if (checkUsername)
                //    return BadRequest(new { Message = "Username Unavailable!" });

                //var checkEmail = await _userRepository.ChechEmailExist(user.Email);

                //if (checkEmail)
                //    return BadRequest(new { Message = "Email Unavailable!" });

                var result = await _userRepository.UpdateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}/delete-user-by-id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == null) 
                return BadRequest(new { Message = "No Users Have Been Found With That Id!" });

            var result = await _userRepository.DeleteUser(id);
            return Ok(new { Message = "User Has Been Deleted!" });

        }

        [HttpPost("authenticate-login")]
        public async Task<IActionResult> AuthenticateUser(User user)
        {
            if(user == null)
                return BadRequest();
            var result = await _userRepository.AuthenticateLogin(user);

            

            if (result == null)
                return BadRequest(new { Message = "User Not Found!"});

            result.Token = GenreateJWTToken(result);

            return Ok(new { Message = "Login Successful!", Token = result.Token });
        }

        private string GenreateJWTToken(User user)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yhreuhr83swjadkadasjdjfasdasdfsds"));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var userClaims = new[]
            //{
            //    new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            //    new Claim(ClaimTypes.GivenName, user.Firstname + " " + user.Lastname),
            //    new Claim(ClaimTypes.Name, user.Username),
            //    new Claim(ClaimTypes.Email, user.Email)
            //};

            //var token = new JwtSecurityToken(
            //    issuer: "https://localhost:7272",
            //    audience: "https://localhost:7272",
            //    claims: userClaims,
            //    expires: DateTime.Now.AddSeconds(10),
            //    signingCredentials: credentials);

            //return new JwtSecurityTokenHandler().WriteToken(token);


            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Yhreuhr83swjadkadasjdjfasdasdfsds");
            var identity = new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                 new Claim(ClaimTypes.GivenName, user.Firstname + " " + user.Lastname),
                 new Claim(ClaimTypes.Name, user.Username),
                 new Claim(ClaimTypes.Email, user.Email),
            });

            var creditials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = creditials,
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }
    }
}
