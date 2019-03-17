using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class MaterialController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public MaterialController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Material
        public ActionResult Index()
        {
            ViewBag.Materiales = context.Material.Where(x => x.EsActivo == true).ToList();
            return View();
        }

        // GET: Material/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Material/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Material/Create
        [HttpPost]
        public ActionResult Create(Material m)
        {
            try
            {
                m.FechaAlt = DateTime.UtcNow;
                m.FechaMod = DateTime.UtcNow;
                m.EsActivo = true;
                context.Material.Add(m);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var material = context.Material.Where(x => x.Id == id).FirstOrDefault();
                
                return View(material);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Material/Edit/5
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

        // GET: Material/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Material/Delete/5
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

        [HttpGet]
        public JsonResult GetMaterials(int id)
        {
            var materials = context.Material.Where(x => x.EsActivo == true).ToList();
            return Json(materials, JsonRequestBehavior.AllowGet);
        }
    }
}
