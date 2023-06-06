using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Repository;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository AccountRepo)
        {
            accountRepo = AccountRepo;
        }
        //anchor tag
        public IActionResult Login()
        {
            return View();
        }
        //Submit
        [HttpPost]
        [ValidateAntiForgeryToken]//not  internal requ :reject
        public IActionResult Login(Account account)
        {
            if(accountRepo.Found(account.UserName,account.Password))
            {
                Account accountModel = accountRepo.Find(account.UserName, account.Password);
                //create cookie
                ClaimsIdentity identity = 
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("Id",accountModel.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, accountModel.UserName));
                //logic to get accunt role
                //query 
                identity.AddClaim(new Claim(ClaimTypes.Role,"Admin"));

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                return RedirectToAction("AdminDash", "Filtter");
            }
            return View();
        }
        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
