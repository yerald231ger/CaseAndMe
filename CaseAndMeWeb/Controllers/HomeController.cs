using CaseAndMeWeb.Services.Repository;
using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext context { get; set; }
        
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            ViewBag.pDestacados = new List<Producto>();
            ViewBag.pNuevos = new List<Producto>();
            if (context.Productos.Count() != 0)
            {
                ViewBag.pDestacados = context.Productos.Where(x=> x.EsActivo == true).Take(10).ToList();
                ViewBag.pNuevos = context.Productos.Where(x => x.EsActivo == true).OrderByDescending(x => x.Id).Take(10).ToList();
            }

            return View();
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