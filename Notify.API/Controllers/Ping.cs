using System;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Notify.Api.Controllers
{
    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            ip = ip == "::1" || ip == "127.0.0.1" ? "localhost" : ip;
            return Content(ip);
        }
    }
}