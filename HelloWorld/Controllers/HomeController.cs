using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using System.Web.UI;

namespace HelloWorld.Controllers
{
    //[AuthorizeIPAddress] //Add the IP address filter attribute
    //[Logging] //Add the action filter attribute on the controller
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // int x = 1;  // add me
            // x = x / (x - 1); // add me
            return View();
        }
        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //------------------------------Security----------------------------------------------

        [Authorize]
        [IsAdministrator]
        public ActionResult Notes()
        {
            return View();
        }

        //------------------------------Log in /out ------------------------------------------

        [HttpGet]        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.LoginModel loginModel)
        {
            Session["UserName"] = loginModel.UserName;
            return RedirectToAction("Index");            
        }
        public ActionResult Logoff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }
        public PartialViewResult DisplayLoginName()
        {
           return new PartialViewResult();
        }

        //--------------------------------Cookies---------------------------------
        public ActionResult SetCookie()
        {
            // Name the cookie as MyCookie for later retrieval
            var cookie = new HttpCookie("MyCookie");

            // This cookie will expire about one minute, depends on the browser
            cookie.Expires = DateTime.Now.AddMinutes(1);

            // This cookie will have a simple string value of myUserName
            // but it can be any kind of object.
            cookie.Value = "myUserName";

            // Add the cookie to the response to send it to the browser
            HttpContext.Response.Cookies.Add(cookie);

            return View(cookie);
        }

        public ActionResult GetCookie()
        {
            return View(HttpContext.Request.Cookies["MyCookie"]);
        }

        //-------------------------------RSVP-----------------------------------------

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid) //check on validation
            {
                return View("Thanks", guestResponse);
            }
            else //if false stay on the same page
            {
                return View();
            }
        }

        //-----------------------------Products---------------------------------------
        
            //Show first product
        public ActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        // [OutputCache(Duration = 15, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        //Catchs the data during the first 15 seconds. After that if the user refreshes it will get the data again from the repository 
        //.Any means the catching is being stored in the user's computer if possible and if not it will be stored in the server
        //Show all products
        public ActionResult Products()
        {
            return View(productRepository.Products); //put breakpoint here to try catching Remove action filters first
        }

        public PartialViewResult IncrementCount()
        {
            int count = 0;

            // Check if MyCount exists
            if (Session["MyCount"] != null)
            {
                count = (int)Session["MyCount"];
                count++;
            }

            // Create the MyCount session variable
            Session["MyCount"] = count;

            return new PartialViewResult();

        }
    }
}

