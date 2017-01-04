using Modelo.Cadastros;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Servico.Tabelas;
using Servico.Cadastros;

namespace Projeto01.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private CategoriaServico categoriaServico = new CategoriaServico();


        // GET: Produto
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }

        // GET: Produto/Details/5
        public ActionResult Details(long? id)
        {
            return ObterProdutoPeloId(id);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId((long)id));
            return ObterProdutoPeloId(id);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            return GravarProduto(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterProdutoPeloId(id);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            try
            {
                Produto produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto	" + produto.Nome.ToUpper() + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private ActionResult ObterProdutoPeloId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }


		private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome");
            } else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }


        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag();
                return View(produto);
            }
            catch
            {
                PopularViewBag();
                return View(produto);
            }
        }
    }
}
