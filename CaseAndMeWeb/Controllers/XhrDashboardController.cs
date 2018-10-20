using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CaseAndMeWeb.Services.Repository;
using CaseAndMeWeb.Models;
using Newtonsoft.Json;
using CaseAndMeWeb.Models.DashboardViewModels;
using CaseAndMeWeb.Models.ReportsViewModels;

namespace CaseAndMeWeb.Controllers
{
    [RoutePrefix("xhrd")]
    public class XhrDashboardController : ApiController
    {
        [HttpGet]
        [Route("ventas/{y:int}")]
        public int[] SalesYear(int y)
        {
            return OrdenVentaRepository.SalesYearTotalByMonth(y);
        }

        [HttpGet]
        [Route("productos/topsales/{y:int?}")]
        public TopSalesProductChartViewModel TopSalesProducts(int y = 0)
        {
            var topProductosVendidos = OrdenVentaRepository.ProductosMasVendidos();

            var labels = topProductosVendidos.Select(tpv => tpv.Nombre).ToArray();
            var data = topProductosVendidos.Select(tpv => tpv.Total).ToArray();
            var ids = topProductosVendidos.Select(tpv => tpv.Id).ToArray();

            return new TopSalesProductChartViewModel(labels, data, ids, data.Sum());
        }

        [HttpGet]
        [Route("ventas/semana")]
        public SalesWeek SalesWeek()
        {
            return OrdenVentaRepository.SalesWeeks();
        }

        public IOrdenVentaRepository OrdenVentaRepository { get; }

        public XhrDashboardController(
            IOrdenVentaRepository ordenVentaRepository,
            IProductoRepository productoRepository)
        {
            OrdenVentaRepository = ordenVentaRepository;
        }
    }
}