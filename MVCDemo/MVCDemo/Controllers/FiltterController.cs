using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCDemo.Filtters;
using System.Security.Claims;

namespace MVCDemo.Controllers
{
    //[HandelError]//scope all action in this controller
    public class FiltterController : Controller
    {
       // [HandelError]//scope this action
        public IActionResult Index()
        {
            throw new Exception("wawwwwww Exception happen");
            return View();            
        }
        //[HandelError]
        public IActionResult Index2()
        {
            throw new Exception("wawwwwww Exception happen");
            return View();
        }

        [Authorize]//cookie found == not found resturn login
        public IActionResult AdminDash()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                Claim idClaim= User.Claims.FirstOrDefault(c => c.Type == "Id");
                string id = idClaim.Value;
                //User//get infor from cookie with name cookies 
                return Content("Admin");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
