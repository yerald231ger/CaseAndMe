using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class GalleryController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public GalleryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: Gallery
        public ActionResult Index()
        {
            ViewBag.pDestacados = new List<Producto>();
            ViewBag.pNuevos = new List<Producto>();
            var Subcategorias = context.SubCategorias.Include("Categoria").ToList();
            ViewBag.pSubcategorias = Subcategorias;

            var Categorias = context.Categorias.ToList();
            ViewBag.pCategorias = Categorias;

            ViewBag.Dispositivos = context.Dispositivo.ToList();
            ViewBag.Materiales = context.Material.ToList();

            if (context.Productos.Count() != 0)
            {
                ViewBag.pProductos = context.Productos.Include("Inventario").Where(x => x.EsActivo == true).ToList();
            }
            return View();

        }

        // GET: Gallery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
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

        // GET: Gallery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gallery/Edit/5
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

        // GET: Gallery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gallery/Delete/5
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
