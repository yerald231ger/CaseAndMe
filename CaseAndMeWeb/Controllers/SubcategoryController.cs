using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class SubcategoryController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public SubcategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: Subcategory
        public ActionResult Index()
        {
            var Subcategorias = context.SubCategorias.Include("Categoria").ToList(); ;
            ViewBag.Subcategorias = Subcategorias;
            return View();
        }

        // GET: Subcategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subcategory/Details/5
        public ActionResult ByCategory(int id)
        {
            var Subcategorias = context.SubCategorias.Include("Categoria").Where(x => x.IdCategoria == id).ToList();
            ViewBag.Subcategorias = Subcategorias;
            return View();
        }

        // GET: Subcategory/Create
        public ActionResult Create()
        {
            var Categorias = context.Categorias.Where(x => x.EsActivo == true).ToList();
            ViewBag.Categorias = Categorias;
            return View();
        }

        // POST: Subcategory/Create
        [HttpPost]
        public ActionResult Create(SubCategoria s)
        {
            try
            {
                SubCategoria subCategoria = new SubCategoria();
                subCategoria.Nombre = s.Nombre;
                subCategoria.EsActivo = true;
                subCategoria.FechaAlt = DateTime.UtcNow;
                subCategoria.FechaMod = DateTime.UtcNow;
                subCategoria.IdCategoria = s.IdCategoria;
                context.SubCategorias.Add(subCategoria);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subcategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var Categorias = context.Categorias.Where(x => x.EsActivo == true).ToList();
                ViewBag.Categorias = Categorias;

                SubCategoria Subcategoria = context.SubCategorias.Where(x => x.Id == id).FirstOrDefault();
                
                return View(Subcategoria);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Subcategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SubCategoria s)
        {
            try
            {
                var SubCategoria = context.SubCategorias.Where(x => x.Id == s.Id).FirstOrDefault();
                if (SubCategoria != null)
                {
                    SubCategoria.Nombre = s.Nombre;
                    SubCategoria.EsActivo = s.EsActivo;
                    SubCategoria.FechaMod = DateTime.UtcNow;
                    context.SaveChanges();
                    View(SubCategoria);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Subcategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subcategory/Delete/5
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
