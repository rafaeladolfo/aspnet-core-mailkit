using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingMailKit.Domain;
using UsingMailKit.Services.Contracts;

namespace UsingMailKit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private IEmailService _emailService;
        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody]EmailMessage message)
        {
            _emailService.Send(message);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
