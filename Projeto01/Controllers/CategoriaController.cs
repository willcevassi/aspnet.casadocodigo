using Modelo.Tabelas;
using System.Linq;
using System.Web.Mvc;
using Projeto01.Context;
using System.Net;

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
            return View(Context.Categorias.ToList());
        }

        //Get:Categoria/Create
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (categoria == null)
            {
                return HttpNotFound();     
            }
            Context.Categorias.Add(categoria);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = Context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
            
        }

        public ActionResult Details(long? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = Context.Categorias.Find(id);
            if(categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        public ActionResult Delete(long? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = Context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria cat = Context.Categorias.Find(id); 
            if (cat == null)
            {
                return HttpNotFound();    
            }
            Context.Categorias.Remove(cat);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}