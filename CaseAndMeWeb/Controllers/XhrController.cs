using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CaseAndMeWeb.Services.Repository;
using CaseAndMeWeb.Models;
using Newtonsoft.Json;

namespace CaseAndMeWeb.Controllers
{
    [RoutePrefix("/xhr")]
    public class XhrController : ApiController
    {
        [HttpGet]
        public ICollection<Pais> PaisEstados(int i)
        {
            var p = _paisRepository.GetAll();
            return p;
        }
        
        private IPaisRepository _paisRepository;
        private IProductoRepository _productoRepository;

        public XhrController(
            IPaisRepository paisRepository,
            IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _paisRepository = paisRepository;
        }
    }    
}