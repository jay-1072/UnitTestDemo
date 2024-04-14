using Microsoft.AspNetCore.Mvc;
using XUnitDemo.Services;

namespace XUnitDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IPrinterService _printerService;

        public HomeController() { }

        public HomeController(IEmailService emailService, IPrinterService printerService)
        {
            _emailService = emailService;
            _printerService = printerService;
        }

        [HttpGet("index/{gussedNumber}")]
        public string Index(int gussedNumber)
        {
            string result;

            if (gussedNumber > 100)
            {
                result = "Wrong! Try a smaller number";
            }
            else if (gussedNumber < 100)
            {
                result = "Wrong! Try a bigger number";
            }
            else
            {
                result = "You guessed correct number";
            }

            if (_emailService.IsEmailAvailable())
            {
                _emailService.SendEmail();
            }

            if (_printerService.IsPrinterAvailable())
            {
                _printerService.Print("print this message");
            }

            return result;
        }
    }
}
