using CaseAndMeWeb.Services.Repository;
using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseAndMeWeb.Services;
using Unity.Attributes;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CaseAndMeWeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationDbContext context { get; set; }

        public HomeController(ApplicationDbContext context)
        {           
            this.context = context;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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
                ViewBag.pDestacados = context.Productos.Include("Inventario").Where(x=> x.EsActivo == true && x.Id != 0).Take(10).ToList();
                ViewBag.pNuevos = context.Productos.Include("Inventario").Where(x => x.EsActivo == true && x.Id != 0).OrderByDescending(x => x.Id).Take(10).ToList();
            }

            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            base.OnAuthorization(filterContext);

            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).FirstOrDefault() != null)
                return;

            if (string.IsNullOrEmpty(ClaimType) || string.IsNullOrEmpty(ClaimValue))
                return;

            var principal = filterContext.RequestContext.HttpContext.User as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/auth/signin");
                return;
            }

            var claimValue = ClaimValue.Split(','); //Split custom roles and validate custom cliams, issuer and vlaue.
            if (!(principal.HasClaim(x => x.Type == ClaimType && claimValue.Any(v => v == x.Value) && x.Issuer == "")))
            {
                filterContext.Result = new RedirectResult("~/Unauthorize.html");
            }
        }
    }
}