using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class CategoryController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Category
        public ActionResult Index()
        {
            //ViewBag.Categorias = context.Categorias.ToList();
            var Categorias = context.Categorias.Select(x => new Categoria2{
                IdCategoria = x.Id,
                Nombre = x.Nombre,
                NoSubCategoria = context.SubCategorias.Where(s => s.IdCategoria == x.Id).ToList().Count(),
                EsActivo = x.EsActivo
            }).ToList();
            ViewBag.Categorias = Categorias;
            return View();
        }

       

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.EsActivo = true;
                categoria.FechaAlt = DateTime.UtcNow;
                categoria.FechaMod = DateTime.UtcNow;
                categoria.Nombre = collection["Nombre"];
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                Categoria categoria = context.Categorias.Where(x => x.Id == id).FirstOrDefault();
                ViewBag.Categoria = categoria;
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categoria m)
        {
            try
            {
                var Categoria = context.Categorias.Where(x => x.Id == id).FirstOrDefault();
                if(Categoria != null)
                {
                    Categoria.Nombre = m.Nombre;
                    Categoria.EsActivo = m.EsActivo;
                    Categoria.FechaMod = DateTime.UtcNow;
                    context.SaveChanges();
                    Categoria categoria = context.Categorias.Where(x => x.Id == id).FirstOrDefault();
                    ViewBag.Categoria = categoria;
                    View(categoria);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var Categoria = context.Categorias.Where(x => x.Id == id).FirstOrDefault();
            if (Categoria != null)
            {
                context.Categorias.Remove(Categoria);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
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
