using Microsoft.Owin;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CaseAndMeWeb.Models;
using System.Linq;
using System.Collections.Generic;
using Openpay;

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

               

                ViewBag.Paises = new SelectList(paisesList, "Id", "Nombre", paisDefault.IdPais);
                ViewBag.Estados = new SelectList(estadosList, "Id", "Nombre", estadoDefault); ;

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

        // GET: Checkout/Pay
        public ActionResult Pay()
        {

            return View();
        }

        // POST: Checkout/Pay
        [HttpPost]
        public ActionResult Pay(IFormCollection collection)
        {
            string API_KEY = "sk_3855563d4260413caaac4ea4a09bd986";
            string MERCHANT_ID = "mffor04cuaydicmocxvb";
            OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY, MERCHANT_ID);
            openpayAPI.Production = false;  //false = Modo pruebas      true = Modo producción

            return View();
        }
    }
}
