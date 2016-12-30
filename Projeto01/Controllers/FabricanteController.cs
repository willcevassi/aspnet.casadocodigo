using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Context;
using Projeto01.Models;
using System.Net;

namespace Projeto01.Controllers
{
    public class FabricanteController : Controller
    {

        private EFContext contexto = new EFContext();

        // GET: Fabricante
        public ActionResult Index()
        {
            return View(contexto.Fabricantes.ToList());
        }

        //GET: Fabricante/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            if(fabricante == null)
            {
                return HttpNotFound();
            }
            contexto.Fabricantes.Add(fabricante);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = contexto.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }



        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante  fabricante = contexto.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        [HttpGet]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = contexto.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante toDelete = contexto.Fabricantes.Find(id);         
            if(toDelete == null)
            {
                return HttpNotFound();
            }
            contexto.Fabricantes.Remove(toDelete);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}