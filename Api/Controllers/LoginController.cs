using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly grpcSetvice grpcService = new grpcSetvice();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            UserService.LoginRequest request = new UserService.LoginRequest() { Password = model.Password, Phone = model.Phone };
            UserService.LoginReply reply = await grpcService.Login(request);
            if (reply.Signup == true)
            {
                return Ok(new { message = "Успешный вход" });
            }
            return Unauthorized(new { message = "Неправильный номер телефона или пароль" });
        }
    }

    public class LoginModel
    {
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
