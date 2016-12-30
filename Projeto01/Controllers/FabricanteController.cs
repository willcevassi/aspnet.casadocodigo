using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Context;

namespace Projeto01.Controllers
{
    public class FabricanteController : Controller
    {

        private EFContext contexto = new EFContext();
        // GET: Fabricante
        public ActionResult Index()
        {
            return View(contexto.Facricantes.OrderBy(f => f.Nome));
        }

        //GET: Fabricante/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}