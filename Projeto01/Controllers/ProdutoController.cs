using Projeto01.Context;
using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class ProdutoController : Controller
    {
        private EFContext Contexto = new EFContext();


        // GET: Produto
        public ActionResult Index()
        {
            return View(Contexto.Produtos.OrderBy(P => P.Nome));
        }

        // GET: Produto/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = Contexto.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (produto == null)
            {
                return HttpNotFound();     
            }

            Contexto.Produtos.Add(produto);
            Contexto.SaveChanges();
            TempData["Message"] = "Produto	" + produto.Nome.ToUpper() + "	incluído com sucesso";
            return RedirectToAction("Index");
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = Contexto.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                Contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                Contexto.SaveChanges();
                TempData["Message"] = "Produto	" + produto.Nome.ToUpper() + "	alterado com sucesso";
                return RedirectToAction("Index");
            }
            return View(produto);
                
            

        }

        // GET: Produto/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = Contexto.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();     
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto toDelete = Contexto.Produtos.Find(id);
            if (toDelete == null)
            {
                return HttpNotFound();
            }
            Contexto.Produtos.Remove(toDelete);
            Contexto.SaveChanges();
            //incluindo os dados do fabricante removida ao TEMPDATA para recuperação da View de Listagem (Index)
            TempData["Message"] = "Produto	" + toDelete.Nome.ToUpper() + "	removido com sucesso";
            return RedirectToAction("Index");
        }
    }
}
