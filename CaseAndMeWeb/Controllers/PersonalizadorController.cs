using CaseAndMeWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class PersonalizadorController : Controller
    {
        protected ApplicationDbContext context { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public PersonalizadorController(ApplicationDbContext context)
        {
            this.context = context;
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.context));
        }
        // GET: Personalizador
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            if(UserId != null)
            {
                ViewBag.Dispositivos = context.Dispositivo.Where(x=> x.Id != 0 && x.EsActivo == true).ToList();
                ViewBag.Materiales = context.Material.Where(x => x.EsActivo == true).ToList();
                ViewBag.Base64Img = getUserImages(UserId);
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        // POST: Personalizador/Index
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {


                foreach (string file in Request.Files)
                {
                    var postedFile = Request.Files[file];
                    string newFileName = Guid.NewGuid().ToString() + ".jpg";
                    if (!string.IsNullOrEmpty(postedFile.FileName))
                    {

                        var filePath = Server.MapPath("~/images/Items/" + newFileName);
                        postedFile.SaveAs(filePath);
                        //producto.UrlImagen = newFileName;
                    }
                }

                //context.Productos.Add(producto);
                //context.SaveChanges();
                //ViewBag.Categorias = context.Categorias.Where(x => x.EsActivo == true).ToList();
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UploadUserFile(FormCollection collection)
        {
            try
            {
                

                var UserId = User.Identity.GetUserId();
                if (!string.IsNullOrEmpty(UserId))
                {
                    GuardaBitacora("UploadUserFile()", "Entra al If");
                    UserImg img = new UserImg();
                    string newFileName = ""; ;
                    foreach (string file in Request.Files)
                    {

                        GuardaBitacora("UploadUserFile()", "Entra al foreach");
                        var postedFile = Request.Files[file];

                        GuardaBitacora("UploadUserFile()", file);
                        newFileName = Guid.NewGuid().ToString() + ".png";
                        if (!string.IsNullOrEmpty(postedFile.FileName))
                        {
                            GuardaBitacora("UploadUserFile()", "Entra al 2o If");
                            string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\UFiles\\" + UserId);

                            GuardaBitacora("UploadUserFile()", directory);
                            Directory.CreateDirectory(directory);

                            var filePath = Server.MapPath("~/Files/UFiles/" + UserId + "/" + newFileName);
                            GuardaBitacora("UploadUserFile()", "Entra al MapPath");
                            //postedFile.SaveAs(filePath);
                            Stream strm = postedFile.InputStream;
                            GenerateThumbnails(0.5, strm, filePath);

                            GuardaBitacora("UploadUserFile()", "GenerateThumbnails");


                            //Generamos imagen Base 64
                            MemoryStream target = new MemoryStream();
                            postedFile.InputStream.CopyTo(target);
                            byte[] imageArray = target.ToArray();
                            string base64Img = Convert.ToBase64String(imageArray);

                            GuardaBitacora("UploadUserFile()", "base64Img");
                            //Generamos imagen Base 64 pequeña
                            Image imagen = Image.FromFile(filePath);
                            string base64ImgSmall = ScaleByPercent(imagen, 10);

                            GuardaBitacora("UploadUserFile()", "base64ImgSmall");
                            img.FileName = newFileName;
                            img.Base64Img = base64Img;
                            img.Base64ImgSmall = base64ImgSmall;
                            img.ImageURL = "/Files/UFiles/" + UserId + "/" + newFileName;
                            GuardaBitacora("UploadUserFile()", "fin");
                        }
                    }

                    return Json(img);
                }


                return View();
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
                return View();
            }
        }


        [HttpPost]
        public ActionResult CreateCustomCase(FormCollection collection)
        {
            try
            {
                var UserId = User.Identity.GetUserId();
                string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\UFiles\\" + UserId);
                string customDiectory = directory + "\\" + "Custom";
                Directory.CreateDirectory(customDiectory);
                string file = Guid.NewGuid().ToString() + ".png";
                string filePath = customDiectory + "\\" + file;

                string idDispositivo = collection["dispositivo[id]"];
                string idMaterial = collection["case[id]"];
                string layout = collection["layout[name]"];
                string imgBase64 = collection["imgBase64"];

                var bytes = Convert.FromBase64String(imgBase64.Replace("data:image/png;base64,", ""));
                using (var ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    image.Save(filePath);
                }

                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        //[HttpPost]
        //public ActionResult UploadUserFile(FormCollection collection)
        //{
        //    try
        //    {
        //        var UserId = User.Identity.GetUserId();
        //        if (!string.IsNullOrEmpty(UserId))
        //        {
        //            UserImg img = new UserImg();
        //            string newFileName = ""; ;
        //            foreach (string file in Request.Files)
        //            {
        //                var postedFile = Request.Files[file];
        //                newFileName = Guid.NewGuid().ToString() + ".png";
        //                if (!string.IsNullOrEmpty(postedFile.FileName))
        //                {
        //                    string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files/UFiles/" + UserId);

        //                    Directory.CreateDirectory(directory);

        //                    var filePath = Server.MapPath("~/Files/UFiles/" + UserId + "/" + newFileName);
        //                    postedFile.SaveAs(filePath);



        //                    Generamos imagen Base 64
        //                    MemoryStream target = new MemoryStream();
        //                    postedFile.InputStream.CopyTo(target);
        //                    byte[] imageArray = target.ToArray();
        //                    string base64Img = Convert.ToBase64String(imageArray);

        //                    Generamos imagen Base 64 pequeña
        //                    Image imagen = Image.FromFile(filePath);
        //                    string base64ImgSmall = ScaleByPercent(imagen, 10);

        //                    img.FileName = newFileName;
        //                    img.Base64Img = base64Img;
        //                    img.Base64ImgSmall = base64ImgSmall;
        //                }
        //            }

        //            return Json(img);
        //        }


        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        return View();
        //    }
        //}


        private List<UserImg> getUserImages(string UserId)
        {
            List<UserImg> list = new List<UserImg>();
            try
            {
                string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\UFiles\\" + UserId);
                if (Directory.Exists(directory))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                    FileInfo[] Files = directoryInfo.GetFiles("*");
                    if (Files.Any())
                    {
                        string[] fileNames = new string[Files.Count()];
                        for (int i = 0; i < Files.Count(); i++)
                        {
                            string pathFile = directory + "\\" + Files[i].Name;
                            Image imagen = Image.FromFile(pathFile);

                            UserImg img = new UserImg();
                            img.FileName = Files[i].Name;
                            img.Base64ImgSmall = ScaleByPercent(imagen, 10);
                            img.ImageURL = "/Files/UFiles/" + UserId +"/"+ Files[i].Name;
                            list.Add(img);
                        }
                        
                        
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
            return list;
        }

        private List<UserImg> getUserImagesBase64(string UserId)
        {
            List<UserImg> list = new List<UserImg>();
            try
            {
                string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Files\\UFiles\\" + UserId);
                if (Directory.Exists(directory))
                {

                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                    FileInfo[] Files = directoryInfo.GetFiles("*");
                    if (Files.Any())
                    {
                        string[] base64File = new string[Files.Count()];
                        for (int i = 0; i < Files.Count(); i++)
                        {
                            UserImg img = new UserImg();
                            string pathFile = directory + "\\" + Files[i].Name;
                            byte[] imageArray = System.IO.File.ReadAllBytes(pathFile);
                            string base64Img = Convert.ToBase64String(imageArray);
                            base64File[i] = base64Img;
                            Image imagen = Image.FromFile(pathFile);

                            img.FileName = Files[i].Name;
                            img.Base64Img = base64Img;
                            img.Base64ImgSmall = ScaleByPercent(imagen, 10);
                            list.Add(img);
                        }

                        
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return list;
        }

        private string ScaleByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            using (var ms = new MemoryStream())
            {
                bmPhoto.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
           
        }

        public class UserImg
        {
            public string FileName { get; set; }
            public string ImageURL { get; set; }
            public string Base64Img { get; set; }
            public string Base64ImgSmall { get; set; }
        }

        private void GuardaBitacora(string Metodo, string Descripcion)
        {
            BitacoraError bError = new BitacoraError();
            bError.Metodo = Metodo;
            bError.Descripcion = Descripcion;
            bError.FechaAlt = DateTime.UtcNow;
            bError.FechaMod = DateTime.UtcNow;
            bError.EsActivo = true;
            context.BitacoraErrores.Add(bError);
            context.SaveChanges();
        }
    }
}
