using CoreFusion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreFusion.Controllers
{

    //このControllerの全てのアクションは認証済みユーザーのみアクセス可能
    [Authorize]
    public class SelectController : Controller 
    {
        public IActionResult Index()
        {
            return View(); //認証済みユーザーのみこのページを見れる
        }

        //認証不要なアクションがある場合、AllowAnonymaus属性を付与
        [AllowAnonymous]
        public IActionResult PublicAccess()
        {
            return View(); //誰でもこのページを見れる
        }

    }

    [Authorize]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
