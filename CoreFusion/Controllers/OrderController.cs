using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFusion.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Roles = "MinimumOrderAge")]
        public IActionResult PlaceOrder()
        {
            return View();
        }
    }
}
