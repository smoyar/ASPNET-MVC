using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework1.Models;

namespace Homework1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendCard(BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks",birthdayCard);
            }
            else
            {
                return View();
            }
        }
    }
}