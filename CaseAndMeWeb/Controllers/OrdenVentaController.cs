using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class OrdenVentaController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public OrdenVentaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: OrdenVenta
        public ActionResult Index()
        {
            var MetodosEnvio = context.MetodosEnvios.ToList();
            var MetodosPago = context.MetodosPagos.ToList();
            var OrdenesVenta = context.OrdenesVentas.OrderByDescending(x => x.FechaMod).ToList();
            ViewBag.OrdenesVenta = (from o in OrdenesVenta
                                    join mp in MetodosPago on o.IdMetodoPago equals mp.Id
                                    join me in MetodosEnvio on o.IdMetodoEnvio equals me.Id
                                    select new
                                    {
                                        o.Id,
                                        o.Folio,
                                        NombreCompleto = o.Nombre + " " + o.Apellido,
                                        o.Email,
                                        MetodoEnvio = me.Nombre,
                                        MetodoPago = mp.Nombre,
                                        o.FechaMod
                                    }).ToList();
            return View();
        }

        // GET: OrdenVenta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenVenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenVenta/Create
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

        // GET: OrdenVenta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenVenta/Edit/5
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

        // GET: OrdenVenta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenVenta/Delete/5
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
