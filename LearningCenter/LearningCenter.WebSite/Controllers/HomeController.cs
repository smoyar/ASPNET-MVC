using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenter.WebSite.Models;
using LearningCenter.Business;


namespace LearningCenter.WebSite.Controllers
{
    public class HomeController : Controller
    {
        //-----------------------Initialization---------------------------

        private readonly IClassManager classManager;
        public HomeController(IClassManager classManager)
        {
            this.classManager = classManager;
        }
        
        public ActionResult Index()
        {
            var classes = classManager.Classes
                                        .Select(t => new LearningCenter.WebSite.Models.ClassModel(t.ClassId, t.ClassName))
                                        .ToArray();
            var model = new IndexModel { Classes = classes };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}