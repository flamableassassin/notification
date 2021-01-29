using Microsoft.AspNetCore.Mvc;

namespace Notify.Api.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet("/check")]
        public ActionResult Index()
        {
            return Content("hi");
        }
    }
}