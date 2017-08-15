using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CaseAndMe.Services.Repository;
using Newtonsoft.Json.Linq;
using CaseAndMe.Models;

namespace CaseAndMe.Controllers
{
    [Produces("application/json")]
    [Route("xhr")]
    public class XhrController : Controller
    {
        [HttpGet("paises/{i:int}/estados")]
        public JsonResult PaisEstados(int i)
        {
            return Json(_paisRepository.GetEstados(i).Select(e => new { e.Id, e.Nombre }));
        }

        private IPaisRepository _paisRepository;

        public XhrController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }
    }
}