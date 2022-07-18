using Microsoft.AspNetCore.Mvc;

namespace WhosAppMVCfront.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatGrupal()
        {
            return View();
        }
    }
}
