using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly grpcSetvice grpcService = new grpcSetvice();

        [HttpPost]

        public async Task<IActionResult> User(UserModel model)
        {
            UserService.GetUserRequest request = new UserService.GetUserRequest() { PhoneNumber = model.Phone };
            UserService.GetUserReply reply = await grpcService.GetUserData(request);

            return Ok(reply);
        }
    }

    public class UserModel
    {
        public string Phone { get; set; }
    }
}
