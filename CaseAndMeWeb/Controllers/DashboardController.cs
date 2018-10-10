﻿using CaseAndMeWeb.Models.DashboardViewModels;
using CaseAndMeWeb.Models.ComponentsViewModel;
using CaseAndMeWeb.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseAndMeWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IOrdenVentaRepository OrdenVentaRepository { get; }

        public DashboardController(IOrdenVentaRepository ordenVentaRepository)
        {
            OrdenVentaRepository = ordenVentaRepository;
        }

        // GET: Dashboard
        public ActionResult Index()
        {            
            return View(new IndexViewModel {
                TableViewModel = GetTableOrdenVenta()
            });
        }

        private TableViewModel GetsTableUltimosUsuarios()
        {
            return null;
        }

        private TableViewModel GetTableOrdenVenta()
        {
            var ordenesVenta = new List<OrdenVentaViewModel>();
            var table = new TableViewModelBuilder<OrdenVentaViewModel>();
            var ordenesVentaTotal = OrdenVentaRepository.Count();

            foreach (var ordenVenta in OrdenVentaRepository.TopOrdenesDeVenta(5))
                ordenesVenta.Add(new OrdenVentaViewModel
                {
                    Folio = ordenVenta.Folio,
                    Fecha = ordenVenta.FechaAlt.ToString("dd MMM yyyy"),
                    MetodoEnvio = ordenVenta.MetodoEnvio.Nombre,
                    MetodoPago = ordenVenta.MetodoPago.Nombre
                });

            table
                .AddTitle("Ordenes de Venta")
                .AddBody("Ultimas 5 ordnes de venta")
                .AddFooter($"Total de ordenes de venta {ordenesVentaTotal}")
                .AddCount(true)
                .AddHeader(ov => ov.Fecha)
                .AddHeader(ov => ov.Folio)
                .AddHeader(ov => ov.MetodoPago)
                .DisplayName("Metodo de pago")
                .AddHeader(ov => ov.MetodoEnvio)
                .DisplayName("Metodo de Envio");

            return table.DataSource(ordenesVenta);
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
