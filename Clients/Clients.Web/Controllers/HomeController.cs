using Clients.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ClientsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;

        public HomeController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GenerateDocument(string SocialNumber)
        {

            return _clientService.GenerateDocumentBySocialNumber(SocialNumber);

        }
    }
}
