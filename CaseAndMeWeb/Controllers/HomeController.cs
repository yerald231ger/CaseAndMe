using CaseAndMe.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class HomeController : Controller
    {
        public IPaisRepository _paisRepository { get; }

        public HomeController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public ActionResult Index()
        {
            var d = _paisRepository.GetAll();
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