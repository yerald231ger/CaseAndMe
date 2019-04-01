using CaseAndMeWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
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
            var Dispositivos = context.Dispositivo.Where(x => x.Id != 0).ToList();
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
            //var MaskMarcas = getMaskMarcas();
            var MaskMarcas = context.Dispositivo.Select(x=> x.Marca).Distinct().ToList();
            //var MaskCases = getMaskCases(MaskMarca);
            ViewBag.MaskMarcas = MaskMarcas;
            return View();
        }

        private List<string> getMaskMarcas()
        {
            List<string> marcas = new List<string>();

            string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Content\\Customizer\\img\\mask\\");
            if (Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                marcas = directoryInfo.GetDirectories("*").Select(x=> x.Name).ToList();
            }

            return marcas;
        }

        [HttpGet]
        public ActionResult getMaskCaseTypes(string MaskMarca)
        {
            List<string> tipocases = new List<string>();

            string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Content\\Customizer\\img\\mask\\" + MaskMarca);
            if (Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                tipocases = directoryInfo.GetDirectories("*").Select(x => x.Name).ToList();
            }

            return Json(tipocases, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getMaskCases(string MaskMarca, string CaseType)
        {
            List<string> cases = new List<string>();

            string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Content\\Customizer\\img\\mask\\" + MaskMarca + "\\" + CaseType);
            if (Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                cases = directoryInfo.GetFiles("*").Select(x => x.Name).ToList();
            }

            return Json(cases, JsonRequestBehavior.AllowGet);
        }

        // POST: Device/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Dispositivo d = new Dispositivo();
                d.EsActivo = true;
                d.FechaAlt = DateTime.UtcNow;
                d.FechaMod = DateTime.UtcNow;
                d.Mascaras = collection["hdnMascara"]; 
                d.Nombre = collection["Nombre"];
                d.EsActivo = true;
                d.Marca = collection["ddlMarca"];
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
                var MaskMarcas = context.Dispositivo.Select(x => x.Marca).Distinct().ToList();
                ViewBag.MaskMarcas = MaskMarcas;
                var Dispositivo = context.Dispositivo.Where(x => x.Id == id).FirstOrDefault();

                //Cargamos lista de tipo de cases
                List<string> tipocases = new List<string>();
                string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Content\\Customizer\\img\\mask\\" + Dispositivo.Marca);
                if (Directory.Exists(directory))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                    tipocases = directoryInfo.GetDirectories("*").Select(x => x.Name).ToList();
                }
                ViewBag.CasesType = tipocases;

                //Recuperamos lista de Cases
                List<object> mascaras = new List<object>();
                foreach (string s in tipocases)
                {
                    List<string> lcases = new List<string>();
                    directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Content\\Customizer\\img\\mask\\" + Dispositivo.Marca + "\\" + s);
                    if (Directory.Exists(directory))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                        lcases = directoryInfo.GetFiles("*").Select(x => x.Name).ToList();
                    }
                    object objCase = new
                    {
                        marca = Dispositivo.Marca,
                        tipoCase = s,
                        listaCases = lcases
                    };
                    mascaras.Add(objCase);
                }
                ViewBag.Mascaras = mascaras;


                if (Dispositivo.Mascaras != null && Dispositivo.Mascaras.Any())
                {
                    var listMascaras = Dispositivo.Mascaras.Split(',');
                    List<string> listMyCases = new List<string>();
                    List<string> listMyCasesType = new List<string>();
                    if (listMascaras.Any())
                    {
                        foreach (string m in listMascaras)
                        {
                            string strCase = m.Substring(m.LastIndexOf('\\') + 1);
                            string strCaseType = m.Replace(Dispositivo.Marca + "\\", "");
                            strCaseType = strCaseType.Replace("\\" + strCase, "");
                            listMyCases.Add(strCase);
                            listMyCasesType.Add(strCaseType);

                        }
                    }
                    
                    ViewBag.listMyCasesType = listMyCasesType;
                    ViewBag.listMyCases = listMyCases;
                }
                
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
                    dispositivo.Mascaras = d.Mascaras;
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
