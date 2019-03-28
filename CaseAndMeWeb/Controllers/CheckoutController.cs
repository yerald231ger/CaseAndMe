using Microsoft.Owin;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CaseAndMeWeb.Models;
using System.Linq;
using System.Collections.Generic;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using Microsoft.AspNet.Identity.EntityFramework;

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
        public ActionResult Pay(string amount, string description)
        {
            ViewBag.amount = "120.0";
            ViewBag.description = "description--";

            return View();
        }

        // POST: Checkout/Pay
        [HttpPost]
        public ActionResult PayReturn()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

            OpenpayAPI api = new OpenpayAPI("sk_3855563d4260413caaac4ea4a09bd986", "mffor04cuaydicmocxvb");

            Customer customer = new Customer();
            customer.Name = user.Nombre;
            customer.LastName = user.PrimerApellido;
            customer.PhoneNumber = user.PhoneNumber;
            customer.Email = user.Email;

            ChargeRequest r = new ChargeRequest();
            r.Method = "card";
            r.SourceId = Request.Form["token_id"].ToString();
            r.Amount =  decimal.Parse(Request.Form["amount"].ToString());
            r.Description = Request.Form["description"].ToString();
            r.DeviceSessionId = Request.Form["deviceIdHiddenFieldName"].ToString();
            r.Customer = customer;

            Charge charge = api.ChargeService.Create(r);

            return View();
        }
    }
}
