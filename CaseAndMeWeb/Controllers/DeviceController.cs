using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class DeviceController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public DeviceController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Device
        public ActionResult Index()
        {
            var Dispositivos = context.Dispositivo.ToList();
            ViewBag.Dispositivos = Dispositivos;
            return View();
        }

        // GET: Device/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Device/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Device/Create
        [HttpPost]
        public ActionResult Create(Dispositivo d)
        {
            try
            {
                d.EsActivo = true;
                d.FechaAlt = DateTime.UtcNow;
                d.FechaMod = DateTime.UtcNow;
                context.Dispositivo.Add(d);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Device/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var Dispositivo = context.Dispositivo.Where(x => x.Id == id).FirstOrDefault();
                return View(Dispositivo);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Device/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Dispositivo d)
        {
            try
            {
                var dispositivo = context.Dispositivo.Where(x => x.Id == id).FirstOrDefault();
                if (dispositivo != null)
                {
                    dispositivo.Nombre = d.Nombre;
                    dispositivo.EsActivo = d.EsActivo;
                    dispositivo.FechaMod = DateTime.UtcNow;
                    context.SaveChanges();
                    View(dispositivo);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Device/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Device/Delete/5
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
