using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class PersonalizadorController : Controller
    {
        // GET: Personalizador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Personalizador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personalizador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personalizador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personalizador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personalizador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personalizador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personalizador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
