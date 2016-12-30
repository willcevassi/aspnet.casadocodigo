using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Context;

namespace Projeto01.Controllers
{
    public class CategoriaController : Controller
    {
        //public static List<Categoria> Categorias = new List<Categoria>() {
        //    new Categoria() {
        //        CategoriaId = 1,
        //        Nome = "Notebooks"
        //    },
        //    new Categoria() {
        //        CategoriaId = 2,
        //        Nome = "Monitores"
        //    },
        //    new Categoria() {
        //        CategoriaId = 3,
        //        Nome = "Impressoras"
        //    },
        //    new Categoria() {
        //        CategoriaId = 4,
        //        Nome = "Mouses"
        //    },
        //    new Categoria() {
        //        CategoriaId = 5,
        //        Nome = "Desktops"
        //    }
        //};


        private EFContext Context = new EFContext();

        // GET: Categoria
        public ActionResult Index()
        {
            return View(Context.Categorias.OrderBy(c => c.Nome));
        }

        //Get:
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoria.CategoriaId = Context.Categorias.Select(c => c.CategoriaId).Max() + 1; 
            Context.Categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id) {
            return View(Context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            Context.Categorias.Remove(Context.Categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            Context.Categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id) {
            return View(Context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        public ActionResult Delete(long id) {
            return View(Context.Categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria) {
            Context.Categorias.Remove(Context.Categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }

    }
}