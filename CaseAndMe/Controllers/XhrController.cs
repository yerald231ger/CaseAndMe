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

namespace CaseAndMe.Controllers
{
    [Produces("application/json")]
    [Route("xhr")]
    public class XhrController : Controller
    {
        private string cachekey = "xhrcontroller";

        [HttpGet("paises/{i:int}/estados")]
        public string PaisEstados(int i)
        {
            var keyentry = $"{cachekey}-{nameof(PaisEstados)}-{i}";

            if (!_cache.TryGetValue(keyentry, out string result))
            {
                result = JsonConvert.SerializeObject(_paisRepository.GetEstados(i).Select(e => new { e.Id, e.Nombre }));
                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                _cache.Set(keyentry, result, cacheEntryOptions);
            }

            return result;
        }

        [HttpGet("paises/{i:int}/estados")]
        public string SearchArticles(string expression)
        {
            var keyentry = $"{cachekey}-{nameof(SearchArticles)}-{expression}";

            if (!_cache.TryGetValue(keyentry, out string result))
            {
                result = JsonConvert.SerializeObject(_paisRepository.GetEstados(i).Select(e => new { e.Id, e.Nombre }));

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                _cache.Set(keyentry, result, cacheEntryOptions);
            }

            return "";
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