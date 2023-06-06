using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class StateController : Controller
    {
        int count;
        public StateController()
        {
            count = 0;
        }

        public IActionResult SetCookie()
        {
            //logic
            //store cookie client using response "Per Client Per Browser"
            //Type of cookie
            //1)Persietent cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Name", "Mohamed", options);
            //2)Session cookie
            HttpContext.Response.Cookies.Append("Color", "Red");


            
            //logic
            return Content("Cookie Save success");
        }
        
        public IActionResult GetCookie()
        {
            //get info from Request client 
            string n= HttpContext.Request.Cookies["Name"];
            string c = HttpContext.Request.Cookies["Color"];
            return Content($"Name={n} ,Color={c}");
        }

        public IActionResult SetSession()
        {
            //logic
            //save session
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 30);
            return Content("Session data Saved");
        }

        public ActionResult GetSession()
        {
            //logic
            string n= HttpContext.Session.GetString("Name");
            int a = HttpContext.Session.GetInt32("Age").Value;
            return Content($"Name = {n} \t Age={a}");
        }

        public IActionResult Index()
        {
            count++;
            return Content($"Count={count}");
        }

        public IActionResult First()
        {
            string msg = "Hello From TempData";
            TempData["MSG"] = msg;//cookie  or session
            return Content("Data Save Success");
        }

        public IActionResult Second()
        {
            string msg = "Empty Msg";
            if (TempData.ContainsKey("MSG"))
            {
                //msg=TempData["MSG"].ToString();//normal read tempdata
                msg = TempData.Peek("MSG").ToString();//Read without delete from cookie
            }
            return Content($"Second MEssage ={msg}");
        }

        public IActionResult Third()
        {
            // string msg = TempData["MSG"].ToString();//normal read tempdata
            string msg = "Empty Msg";
            if (TempData.ContainsKey("MSG"))
            {
                msg = TempData["MSG"].ToString();//normal read tempdata
                TempData.Keep("MSG");
                //TempData.Keep();
                //TempData.Remove("MSG");
            }
            return Content($"Third MEssage ={msg}");
        }
    }
}
