using Microsoft.Owin;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CaseAndMeWeb.Models;
using System.Linq;
using System.Collections.Generic;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;
using System.Drawing;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using CaseAndMeWeb.Utilities;
using System.Text;

namespace CaseAndMeWeb.Controllers
{
    public class CheckoutController : Controller
    {

        public ApplicationDbContext context { get; set; }

        public CheckoutController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        // GET: Checkout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cart(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/checkoutProceed
        public ActionResult CheckoutProceed()
        {
            return View();
        }

        // POST: Checkout/CheckoutProceed
        [HttpPost]
        public ActionResult CheckoutProceed(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/Buy
        public ActionResult Buy()
        {
            return View();
        }

        // POST: Checkout/Buy
        [HttpPost]
        public ActionResult Buy(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/Deliver
        public ActionResult Deliver()
        {

            var userId = User.Identity.GetUserId();
            var usuario = context.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (usuario != null)
            {



                int estadoDefault = usuario.IdEstado;
                var paisDefault = context.Estados.Where(x => x.Id == estadoDefault).FirstOrDefault();

                var paisesList = context.Paises.ToList();
                var estadosList = context.Estados.Where(x => x.IdPais == paisDefault.IdPais).ToList();



                ViewBag.Paises = new SelectList(paisesList, "Id", "Nombre", paisDefault.IdPais);
                ViewBag.Estados = new SelectList(estadosList, "Id", "Nombre", estadoDefault); ;

                usuario.PrimerApellido = usuario.PrimerApellido + " " + usuario.SegundoApellido;

                return View(usuario);
            }
            else
            {
                return View();
            }
        }

        // POST: Checkout/Deliver
        [HttpPost]
        public ActionResult Deliver(IFormCollection collection)
        {
            return View();
        }

        // GET: Checkout/Pay
        public ActionResult Pay(string amount, string description)
        {
            ViewBag.amount = "120.0";
            ViewBag.description = "description--";

            return View();
        }

        // POST: Checkout/Pay
        [HttpPost]
        public ActionResult PayReturn()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

            //Obtenemos los datos de los productos generados por el cliente
            List<oList> oList = JsonConvert.DeserializeObject<List<oList>>(Request.Form["oList"].ToString());


            OpenpayAPI api = new OpenpayAPI("sk_3855563d4260413caaac4ea4a09bd986", "mffor04cuaydicmocxvb");

            Customer customer = new Customer();
            customer.Name = user.Nombre;
            customer.LastName = user.PrimerApellido;
            customer.PhoneNumber = user.PhoneNumber;
            customer.Email = user.Email;

            ChargeRequest r = new ChargeRequest();
            r.Method = "card";
            r.SourceId = Request.Form["token_id"].ToString();
            r.Amount = obtenerCostoTotal(oList);
            r.Description = Request.Form["description"].ToString();
            r.DeviceSessionId = Request.Form["deviceIdHiddenFieldName"].ToString();
            r.Customer = customer;

            Charge charge = api.ChargeService.Create(r);

            if (charge.Status == "completed")
            {
                var users = context.Users;
                var admins = from u in users
                             where u.Roles.Where(x => x.RoleId == "A").Any()
                             select u;


                //Generamos y guardamos imagenes personalizadas 
                //y generamos Orden de Venta
                foreach (var o in oList)
                {
                    //Creamos Orden de Venta
                    OrdenVenta ordenVenta = new OrdenVenta();
                    ordenVenta.Folio = ObtenerNuevoFolio();
                    ordenVenta.EsActivo = true;
                    ordenVenta.FechaAlt = DateTime.UtcNow;
                    ordenVenta.FechaMod = DateTime.UtcNow;
                    ordenVenta.IdMetodoEnvio = 3; //Envo Normal
                    ordenVenta.IdMetodoPago = 1; // Debito/Credito
                    ordenVenta.IdUser = userId;
                    ordenVenta.Nombre = o.D.Nombre;
                    ordenVenta.Apellido = o.D.Apellido;
                    ordenVenta.CP = o.D.CP;
                    ordenVenta.Ciudad = o.D.Ciudad;
                    ordenVenta.Colonia = o.D.Colonia;
                    ordenVenta.Direccion = o.D.Direccion;
                    ordenVenta.Email = o.D.Email;
                    ordenVenta.Estado = o.D.Estado;
                    ordenVenta.Pais = o.D.Pais;
                    ordenVenta.Telefono = o.D.Telefono;
                    context.OrdenesVentas.Add(ordenVenta);
                    context.SaveChanges();
                    int idOrdenVenta = ordenVenta.Id;

                    //Creamos Orden de Venta Detalle 
                    foreach (var ovd in o.OVD)
                    {
                        OrdenVentaDetalle ordenVentaDet = new OrdenVentaDetalle();
                        ordenVentaDet.IdOrdenVenta = idOrdenVenta;
                        ordenVentaDet.IdDipositivo = ovd.D;
                        ordenVentaDet.IdProducto = ovd.P;
                        ordenVentaDet.IdMaterial = ovd.M;
                        ordenVentaDet.Cantidad = ovd.Q;
                        ordenVentaDet.FechaAlt = DateTime.UtcNow;
                        ordenVentaDet.FechaMod = DateTime.UtcNow;
                        ordenVentaDet.EsActivo = true;
                        ordenVentaDet.isCustom = ovd.isCustom;
                        double precio = context.Productos.Where(x => x.Id == ovd.P).FirstOrDefault().Precio;
                        ordenVentaDet.Precio = (double)(decimal.Round((decimal)precio, 2, MidpointRounding.AwayFromZero));
                        if (ovd.isCustom)
                        {
                            precio = context.Material.Where(x => x.Id == ovd.M).FirstOrDefault().precio;
                            ordenVentaDet.Precio = (double)(decimal.Round((decimal)precio, 2, MidpointRounding.AwayFromZero));
                            string file = CreateCustomCase(ovd);
                            ordenVentaDet.Imagen = file;
                        }
                        context.OrdenesVentasDetalle.Add(ordenVentaDet);
                        context.SaveChanges();
                    }

                    //ENVIAMOS CORREOS AL CLIENTE 
                    var objMail = new Mail();
                    var mail = new MailModel();
                    var to = new List<MailAdress>();
                    mail.body = creaOrdenCompraHTML(oList);
                    mail.subject = "Case&Me - Orden de Compra";
                    to.Add(new MailAdress { email = user.Email });
                    mail.emailsTo = to;
                    objMail.sendMail(mail);

                    //ENVIAMOS CORREOS AL ADMIN 
                    objMail = new Mail();
                    mail = new MailModel();
                    to = new List<MailAdress>();
                    mail.body = creaOrdenVentaHTML(ordenVenta.Folio);
                    mail.subject = "Case&Me - Orden de Venta " + ordenVenta.Folio;

                    foreach(var u in admins)
                    {
                        to.Add(new MailAdress { email = u.Email });
                    }
                    mail.emailsTo = to;
                    objMail.sendMail(mail);
                }





            }
            return View();
        }

        /// <summary>
        /// Crea HTML de Orden de Compra 
        /// </summary>
        /// <param name="oList"></param>
        /// <returns></returns>
        private string creaOrdenCompraHTML(List<oList> oList)
        {
            var dispositivos = context.Dispositivo.ToList();
            var productos = context.Productos.ToList();
            var materiales = context.Material.ToList();

            string body = "";
            string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\EmailFiles\\");
            string path = directory + "\\" + "OrdenCompra.html";
            if (System.IO.File.Exists(path))
            {
                body = System.IO.File.ReadAllText(path, Encoding.UTF8);
                string bodyTemp = "";
                decimal amount = obtenerCostoTotal(oList);
                var ovdList = oList[0].OVD;
                for (int i = 0; i < ovdList.Count; i++)
                {
                    int rowNo = i + 1;
                    string row = "<tr>"
                        + "<th>" + rowNo.ToString() + "</th>"
                        + "<td>" + ovdList[i].Name + "</td>"
                        + "<td>" + dispositivos.Where(x => x.Id == ovdList[i].D).FirstOrDefault().Nombre + "</td>"
                        + "<td>" + materiales.Where(x => x.Id == ovdList[i].M).FirstOrDefault().Nombre + "</td>"
                        + "<td>" + ovdList[i].Q.ToString() + "</td>"
                        + "<td>$" + ovdList[i].Price.ToString() + "</td>"
                        + "<td>$" + (ovdList[i].Q * ovdList[i].Price).ToString() + "</td>"
                        + "</tr>";
                    bodyTemp = bodyTemp + row;

                }

                //Agregamos datos de envio
                var o = oList[0];
                body = body.Replace("@@@Nombre", o.D.Nombre + " " + o.D.Apellido);
                body = body.Replace("@@@Pais", o.D.Pais);
                body = body.Replace("@@@Estado", o.D.Estado);
                body = body.Replace("@@@Ciudad", o.D.Ciudad);
                body = body.Replace("@@@Direccion", o.D.Direccion);
                body = body.Replace("@@@Colonia", o.D.Colonia);
                body = body.Replace("@@@CP", o.D.CP);
                body = body.Replace("@@@Telefono", o.D.Telefono);

                string rowAmount = "<tr><td style='text-align:right; '  colspan='7'>Total: <b>$" + amount.ToString() + "</b></td></tr>";
                bodyTemp = bodyTemp + rowAmount;
                body = body.Replace("@@@ROWS", bodyTemp);
            }
            return body;
        }


        /// <summary>
        /// Crea HTML de Orden de Venta 
        /// </summary>
        /// <param name="oList"></param>
        /// <returns></returns>
        private string creaOrdenVentaHTML(string Folio)
        {
            var dispositivos = context.Dispositivo.ToList();
            var productos = context.Productos.ToList();
            var materiales = context.Material.ToList();

            string body = "";
            string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\EmailFiles\\");
            string path = directory + "\\" + "OrdenVenta.html";
            if (System.IO.File.Exists(path))
            {
                body = System.IO.File.ReadAllText(path, Encoding.UTF8);

                body = body.Replace("@@@FolioOrdenVenta", Folio);
            }
            return body;
        }

        /// <summary>
        /// Generamos el costo total en base a Ids. 
        /// </summary>
        /// <param name="oList"></param>
        /// <returns></returns>
        private decimal obtenerCostoTotal(List<oList> oList)
        {
            decimal costoTotal = 0;
            foreach (var o in oList)
            {
                foreach (var ovd in o.OVD)
                {
                    //costoTotal = costoTotal + (decimal)(ovd.Price * ovd.Q);
                    if (ovd.isCustom)
                    {
                        double precioMaterial = context.Material.Where(x => x.Id == ovd.M).Select(x => x.precio).FirstOrDefault();
                        costoTotal = costoTotal + (decimal)(precioMaterial * ovd.Q);
                    }
                    else
                    {
                        double precioProducto = context.Productos.Where(x => x.Id == ovd.P).Select(x => x.Precio).FirstOrDefault();
                        costoTotal = costoTotal + (decimal)(precioProducto * ovd.Q);
                    }

                }
            }

            //Retornamos costo total con 2 decimales
            return decimal.Round(costoTotal, 2, MidpointRounding.AwayFromZero);
        }

        private string ObtenerNuevoFolio()
        {
            string nuevoFolio = "00001";
            var ordenes = context.OrdenesVentas.ToList();
            if (ordenes.Any())
            {
                var OrdenesVenta = context.OrdenesVentas;
                var stFolios = OrdenesVenta.Select(x => x.Folio).ToList();
                var intFolios = stFolios.Select(x => int.Parse(x)).OrderBy(x => x);
                var ultimoFolio = intFolios.Last();
                int intNuevoFolio = ultimoFolio + 1;
                nuevoFolio = intNuevoFolio.ToString().PadLeft(4, '0');
            }
            return nuevoFolio;
        }

        /// <summary>
        /// Convierte una imagenBase64 en archivo png 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public string CreateCustomCase(OrdenVentaDispositivo ovd)
        {
            string file = "";
            try
            {
                var UserId = User.Identity.GetUserId();
                string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\UFiles\\" + UserId);
                string customDiectory = directory + "\\" + "Custom";
                Directory.CreateDirectory(customDiectory);
                file = Guid.NewGuid().ToString() + ".png";
                string filePath = customDiectory + "\\" + file;

                int idDispositivo = ovd.D;
                int idMaterial = ovd.M;
                string imgBase64 = ovd.imgBase64;

                var bytes = Convert.FromBase64String(imgBase64.Replace("data:image/png;base64,", ""));
                using (var ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    image.Save(filePath);
                }
;
            }
            catch (Exception ex)
            {
                BitacoraError bError = new BitacoraError();
                bError.Metodo = "CreateCustomCase()";
                bError.Descripcion = ex.Message + ". " + ex.InnerException;
                bError.FechaAlt = DateTime.UtcNow;
                bError.FechaMod = DateTime.UtcNow;
                bError.EsActivo = true;
                context.BitacoraErrores.Add(bError);
                context.SaveChanges();
            }
            return file;
        }

        public class oList
        {
            public DatosEnvio D { get; set; }
            public List<OrdenVentaDispositivo> OVD { get; set; }
        }

        //D = DatosEnvio: Datos a quien se le enviar� el producto
        public class DatosEnvio
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string CP { get; set; }
            public string Ciudad { get; set; }
            public string Colonia { get; set; }
            public string Direccion { get; set; }
            public string Email { get; set; }
            public string Estado { get; set; }
            public string Pais { get; set; }
            public string Telefono { get; set; }
        }


        //OVD = Orden de Venta de Dispositivo: Datos de la orden de Venta y el dispositivo
        public class OrdenVentaDispositivo
        {
            //D = Id del dispositivo
            public int D { get; set; }

            //Img = Imagen del producto a comprar
            public string Img { get; set; }

            //M = Id del material
            public int M { get; set; }

            //Name = Nombre del producto
            public string Name { get; set; }

            //P = Id del producto. Cuando es 0, es un producto personalizado
            public int P { get; set; }

            //Price = Precio por unidad
            public double Price { get; set; }

            //Q = cantidad
            public int Q { get; set; }

            //imgBase64 = Imagen en Base64, se usa para almacenar un personalizado
            public string imgBase64 { get; set; }

            //isCustom = Indica si es o no personalizado
            public bool isCustom { get; set; }

        }

    }
}
