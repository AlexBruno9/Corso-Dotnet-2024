using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace MvcAuthApp.Controllers
{

    public class ReservedController : Controller
    {
        //  GET: /Reserved/Index
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }

}