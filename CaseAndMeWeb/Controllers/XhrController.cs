using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CaseAndMeWeb.Services.Repository;
using CaseAndMeWeb.Models;
using Newtonsoft.Json;

namespace CaseAndMeWeb.Controllers
{
    [RoutePrefix("xhr")]
    public class XhrController : ApiController
    {
        [HttpGet]
        [Route("Paises")]

        public ICollection<KeyValuePair<int, string>> Paises()
        {
            return _paisRepository.GetAll().Select(p => new KeyValuePair<int, string>(p.Id, p.Nombre)).ToList();
        }

        [HttpGet]
        [Route("Paises/{i:int}/Estados")]
        public ICollection<KeyValuePair<int, string>> ObtenerEstadosPais(int i)
        {
            return _paisRepository.GetEstados(i).Select(e => new KeyValuePair<int, string>(e.Id, e.Nombre)).ToList();
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