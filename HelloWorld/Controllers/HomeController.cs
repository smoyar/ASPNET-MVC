﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
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
        public ActionResult Products()
        {
            var products = new Product[]
            {
        new Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount =1},
        new Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount =3},
        new Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount =0},
        new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount =5},
            };

            return View(products);
        }
    }
}
