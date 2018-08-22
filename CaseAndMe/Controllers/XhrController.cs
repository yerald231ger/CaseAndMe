using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CaseAndMe.Services.Repository;
using Newtonsoft.Json.Linq;
using CaseAndMe.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CaseAndMe.Controllers
{
    [Route("xhr")]
    [Produces("application/json")]
    public class XhrController : Controller
    {
        [HttpGet("paises/{i:int}/estados")]
        public string PaisEstados(int i)
        {
            var keyentry = ControllerContext.HttpContext.Request.Path;

            if (!_cache.TryGetValue(keyentry, out string result))
            {
                result = JsonConvert.SerializeObject(_paisRepository.GetEstados(i).Select(e => new { e.Id, e.Nombre }));
                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                _cache.Set(keyentry, result, cacheEntryOptions);
            }

            return result;
        }

        [HttpGet("search/{expresion}/productos")]
        public string SearchArticles(string expresion)
        {
            var keyentry = ControllerContext.HttpContext.Request.Path;

            if (!_cache.TryGetValue(keyentry, out string result))
            {
                result = JsonConvert.SerializeObject(_productoRepository.FiltrarProductos(expresion).Select(p => new { p.Id, p.Nombre }));

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                _cache.Set(keyentry, result, cacheEntryOptions);
            }

            return result;
        }
        
        private IPaisRepository _paisRepository;
        private IProductoRepository _productoRepository;
        private IMemoryCache _cache;

        public XhrController(
            IPaisRepository paisRepository,
            IMemoryCache cache,
            IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
            _paisRepository = paisRepository;
            _cache = cache;
        }
    }    
}