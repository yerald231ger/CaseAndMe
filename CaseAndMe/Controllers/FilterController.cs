using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseAndMe.Models.FilterViewModels;

namespace CaseAndMe.Controllers
{
    public class FilterController : Controller
    {
        public IActionResult Index(string expresion)
        {
            return View(new ResultadoViewModel {  Resultado = expresion });
        }
    }
}