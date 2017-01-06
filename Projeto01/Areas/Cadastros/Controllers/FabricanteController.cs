using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servico.Cadastros;

namespace Projeto01.Areas.Cadastros.Controllers
{
    public class FabricanteController : Controller
    {

        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Fabricante
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
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
            return GravarFabricante(fabricante);
        }

        public ActionResult Edit(long? id)
        {
            return ObterFabricantePeloId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }



        public ActionResult Details(long? id)
        {
            return ObterFabricantePeloId(id);
            //var fabricante = contexto.Fabricantes.Include("Produtos.Categoria").Where(f => f.FabricanteId == id).First();
        }

        [HttpGet]
        public ActionResult Delete(long? id)
        {
            return ObterFabricantePeloId(id);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            try
            {
                Fabricante  fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

        private ActionResult ObterFabricantePeloId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
    }
}