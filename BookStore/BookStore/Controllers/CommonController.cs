using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult ViewBagExample()
        {
            //First Way
            ViewBag.Tital = "Chintan";
            //Second Way
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Chintan";

            ViewBag.Data = data;
            //Third Way
            ViewBag.myData = new BookModel() {Id =2,Author="Cintan"};

            return View();
        }
        public IActionResult ViewDataExample()
        {
            //First Way
            ViewData["Name"] = "Chintan Patel";
            //Second Way
            ViewData["Book"] = new BookModel() {Id=3, Author="Chintan" };
            //string               

            return View();
        }
        [ViewData] //If we write view data befor property means that property owner is ViewData
        public string CustomAttribute { get; set; }
        public IActionResult ViewDataAttribute()
        {
            CustomAttribute = "I'm Chintan Patel";
            return View();
        }
    }
}
