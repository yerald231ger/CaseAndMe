using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseAndMe.Controllers
{
    public class CheckoutController : Controller
    {
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

    }
}