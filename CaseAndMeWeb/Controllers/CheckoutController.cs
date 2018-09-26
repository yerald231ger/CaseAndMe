using Microsoft.Owin;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CaseAndMeWeb.Models;
using System.Linq;
using System.Collections.Generic;

namespace CaseAndMeWeb.Controllers
{
    public class CheckoutController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public CheckoutController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        // GET: Checkout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cart(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/checkoutProceed
        public ActionResult CheckoutProceed()
        {
            return View();
        }

        // POST: Checkout/CheckoutProceed
        [HttpPost]
        public ActionResult CheckoutProceed(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/Buy
        public ActionResult Buy()
        {
            return View();
        }

        // POST: Checkout/Buy
        [HttpPost]
        public ActionResult Buy(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/Deliver
        public ActionResult Deliver()
        {
            var userId = User.Identity.GetUserId();
            var usuario = context.Users.Where(x=> x.Id == userId).FirstOrDefault();
            if(usuario != null)
            {
                int estadoDefault = usuario.IdEstado;
                var paisDefault = context.Estados.Where(x => x.Id == estadoDefault).FirstOrDefault();

                var paisesList = context.Paises.ToList();
                var estadosList = context.Estados.Where(x=> x.IdPais == paisDefault.IdPais).ToList();

                var listItemsPaises = new List<SelectListItem>();
                var listItemsEstados = new List<SelectListItem>();

                foreach (var p in paisesList)
                    listItemsPaises.Add(new SelectListItem
                    {
                        Text = p.Nombre,
                        Value = p.Id.ToString(),
                        Selected = p.Id == paisDefault.IdPais
                    });

                foreach (var p in estadosList)
                    listItemsEstados.Add(new SelectListItem
                    {
                        Text = p.Nombre,
                        Value = p.Id.ToString()
                    });

                ViewBag.Paises = new SelectList(paisesList, "Id", "Nombre", paisDefault);
                ViewBag.Estados = listItemsEstados;

                usuario.PrimerApellido = usuario.PrimerApellido + " " + usuario.SegundoApellido;

                return View(usuario);
            }
            else
            {
                return View();
            }
        }

        // POST: Checkout/Deliver
        [HttpPost]
        public ActionResult Deliver(IFormCollection collection)
        {
            return View();
        }
    }
}