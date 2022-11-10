using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.Core.Repository;
using EmployeeManagementSystemCA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userRepository;
        public UserController(IUser _userRepository)
        {
            userRepository = _userRepository;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser(UserRegisterDto registerDto)
        {
            try
            {
                if (registerDto != null)
                {
                    int RegisterStatus = await userRepository.RegisterUser(registerDto);
                    if (RegisterStatus == 1)
                    {
                        return Ok("Registered Successfully");
                    }
                    else if (RegisterStatus == 2)
                    {
                        return BadRequest("User data not as per our records");
                    }
                    else if (RegisterStatus == 3)
                    {
                        return BadRequest("User already Exists");
                    }
                    else
                    {
                        return BadRequest("Unable to register");
                    }
                }
                else
                {
                    return BadRequest("User details not as per our record");
                }
            }
            catch
            {
                return BadRequest("Unable to Register");
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            try
            {
                if (loginDto != null)
                {
                    var LoginStatus = await userRepository.Login(loginDto);
                    var userDetails = userRepository.UserDetails(loginDto.Email);
                    if (LoginStatus == "1")
                    {
                        return BadRequest("user was not found");
                    }
                    else if (LoginStatus == "2")
                    {
                        return BadRequest("wrong password");
                    }
                    else //if(LoginStatus == 3)
                    {
                        return Ok(new
                        {
                            token = LoginStatus,
                            user = userDetails,
                        });

                    }
                    /*else
                    {
                        return BadRequest("Something went wrong");
                    }*/
                }
                else
                {
                    return BadRequest("login details not as per our record");
                }
            }
            catch
            {
                return BadRequest("Unable to login");
            }
        }
        
    }
}

