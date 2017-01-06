using Modelo.Tabelas;
using System.Web.Mvc;
using System.Net;
using Servico.Tabelas;

namespace Projeto01.Areas.Tabelas.Controllers
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

        
        private CategoriaServico categoriaServico = new CategoriaServico();


            
        // GET: Categoria
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        //Get:Categoria/Create
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Edit(long? id) {
            return ObterCategoriaPeloId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Details(long? id) {
            return ObterCategoriaPeloId(id);
        }

        public ActionResult Delete(long? id) {
            return ObterCategoriaPeloId(id);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id) {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        private ActionResult ObterCategoriaPeloId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria   categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
    }
}