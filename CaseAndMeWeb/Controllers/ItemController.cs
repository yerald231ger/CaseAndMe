using CaseAndMeWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class ItemController : Controller
    {
        public ApplicationDbContext context { get; set; }

        public ItemController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Item
        public ActionResult Index()
        {
            var Productos = context.Productos.Include("SubCategoria").Include("SubCategoria.Categoria").ToList();
            ViewBag.Productos = Productos;
            return View();
        }

        // GET: Item/Details/XRL6345
        public ActionResult Details(string id)
        {
            Producto producto = context.Productos.Where(x => x.Codigo == id).FirstOrDefault();
            if(producto != null)
            {
                ViewBag.Dispositivos = context.Dispositivo.ToList();
                ViewBag.Materiales = context.Material.ToList();
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = context.Categorias.Where(x => x.EsActivo == true).ToList();

            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int IdSubCategoria = int.Parse(collection["IdSubCategoria"]);
                Producto producto = new Producto();
                producto.Nombre = collection["Nombre"];
                producto.Descripcion = collection["Descripcion"];
                producto.SubCategoria = context.SubCategorias.Where(x => x.Id == IdSubCategoria).FirstOrDefault();
                producto.EsActivo = true;
                producto.FechaAlt = DateTime.Now;
                producto.FechaMod = DateTime.Now;
                producto.Precio = float.Parse(collection["Precio"]);

                foreach (string file in Request.Files)
                {
                    var postedFile = Request.Files[file];
                    string newFileName = Guid.NewGuid().ToString() + ".jpg";
                    if (!string.IsNullOrEmpty(postedFile.FileName))
                    {

                        var filePath = Server.MapPath("~/images/Items/" + newFileName);
                        postedFile.SaveAs(filePath);
                        producto.UrlImagen = newFileName;
                    }
                }

                context.Productos.Add(producto);
                context.SaveChanges();
                ViewBag.Categorias = context.Categorias.Where(x => x.EsActivo == true).ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var Producto = context.Productos.Include("SubCategoria").Include("SubCategoria.Categoria").Where(x => x.Id == id).FirstOrDefault();
                ViewBag.Categorias = context.Categorias.Where(x => x.EsActivo == true).ToList();
                ViewBag.SubCategorias = context.SubCategorias.Where(x => x.EsActivo == true).ToList();
               

                return View(Producto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto p)
        {
            try
            {
                var Producto = context.Productos.Where(x => x.Id == id).FirstOrDefault();
                if (Producto != null)
                {
                    Producto.Nombre = p.Nombre;
                    Producto.IdSubCategoria = p.IdSubCategoria;
                    Producto.Codigo = p.Codigo;
                    Producto.EsActivo = (bool)p.EsActivo;
                    Producto.Precio = p.Precio;
                    Producto.FechaMod = DateTime.UtcNow;

                    foreach (string file in Request.Files)
                    {
                        var postedFile = Request.Files[file];
                        if (!string.IsNullOrEmpty(postedFile.FileName))
                        {
                            string newFileName = "";
                            if (string.IsNullOrEmpty(Producto.UrlImagen))
                            {

                                newFileName = Guid.NewGuid().ToString() + ".jpg";
                                Producto.UrlImagen = newFileName;
                            }
                            else
                                newFileName = Producto.UrlImagen;

                            var filePath = Server.MapPath("~/images/Items/" + newFileName);
                            postedFile.SaveAs(filePath);
                        }
                    }
                    

                    context.SaveChanges();
                    Producto producto = context.Productos.Where(x => x.Id == id).FirstOrDefault();
                    ViewBag.Producto = producto;
                    View(producto);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
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
        public ActionResult getSubCategorias(int idCategoria)
        {
            var list = context.SubCategorias.Where(x => x.IdCategoria == idCategoria && x.EsActivo == true).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
