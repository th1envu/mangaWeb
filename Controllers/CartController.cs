using Microsoft.AspNetCore.Mvc;

namespace WebTruyenTranh.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
