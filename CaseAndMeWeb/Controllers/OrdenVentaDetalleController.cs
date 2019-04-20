using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class OrdenVentaDetalleController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public OrdenVentaDetalleController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: OrdenVentaDetalle
        public ActionResult Index(int? id)
        {
            if(id != null && id != 0)
            {
                var OrdenVenta = context.OrdenesVentas.Where(x => x.Id == id).FirstOrDefault();
                if (OrdenVenta != null)
                {
                    ViewBag.OrdenVenta = OrdenVenta;
                    var productos = context.Productos.ToList();
                    var dispositivos = context.Dispositivo.ToList();
                    var materiales = context.Material.ToList();

                    var OrdenesVentaDetalle = context.OrdenesVentasDetalle.Where(x => x.IdOrdenVenta == OrdenVenta.Id).ToList();
                    ViewBag.OrdenesVentaDetalle = (from ovd in OrdenesVentaDetalle
                                                   join p in productos on ovd.IdProducto equals p.Id
                                                   join d in dispositivos on ovd.IdDipositivo equals d.Id
                                                   join m in materiales on ovd.IdMaterial equals m.Id
                                                   select new
                                                   {
                                                       NombreProducto = p.Nombre,
                                                       NombreDispositivo = d.Nombre,
                                                       NombreMaterial = m.Nombre,
                                                       ovd.Cantidad,
                                                       ovd.Precio,
                                                       ovd.IdProducto,
                                                       ovd.Imagen
                                                   }
                        ).ToList();
                }
            }
            
            return View();
        }

        // GET: OrdenVentaDetalle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenVentaDetalle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenVentaDetalle/Create
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

        // GET: OrdenVentaDetalle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenVentaDetalle/Edit/5
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

        // GET: OrdenVentaDetalle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenVentaDetalle/Delete/5
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
