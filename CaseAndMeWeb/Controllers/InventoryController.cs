using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class InventoryController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public InventoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            var Productos = context.Productos.Include("Inventario").Include("SubCategoria").Include("SubCategoria.Categoria").ToList();
            ViewBag.Productos = Productos;
            return View(ViewBag);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int IdInventario = int.Parse(collection["id"]);
                int Cantidad = int.Parse(collection["cant"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, int cant)
        {
            try
            {

                var inventario = context.Inventarios.Where(x => x.Id == id).FirstOrDefault();
                if (inventario != null)
                {
                    inventario.Cantidad = cant;
                    inventario.FechaMod = DateTime.UtcNow;
                    context.SaveChanges();

                }
                else
                {
                    inventario = new Inventario();
                    inventario.Cantidad = cant;
                    inventario.EsActivo = true;
                    inventario.FechaAlt = DateTime.UtcNow;
                    inventario.FechaMod = DateTime.UtcNow;
                    inventario.Nombre = string.Empty;
                    inventario.Producto = context.Productos.Where(x => x.Id == id).FirstOrDefault();
                    context.Inventarios.Add(inventario);
                    context.SaveChanges();
                }
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
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
