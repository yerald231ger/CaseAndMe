using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseAndMe.Models;
using CaseAndMe.Data;


namespace CaseAndMe.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public HomeController (ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.pDestacados = new List<Producto>();
            ViewBag.pNuevos = new List<Producto>();
            if (context.Productos.Count() != 0)
            {
                ViewBag.pDestacados = context.Productos.Take(10).ToList();
                ViewBag.pNuevos = context.Productos.OrderByDescending(x => x.Id).Take(10).ToList();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
