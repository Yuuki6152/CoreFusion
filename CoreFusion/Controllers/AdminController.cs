using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFusion.Controllers
{
    public class AdminController : Controller
    {
        //"Administrator"ロールを持つユーザーのみアクセス可能
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        //"Administrator"または"Editor"ロールを持つユーザーのみアクセス可能
        [Authorize(Roles = "Administrator,Editor")]
        public IActionResult EditContent()
        {
            return View();
        }
    }
}
