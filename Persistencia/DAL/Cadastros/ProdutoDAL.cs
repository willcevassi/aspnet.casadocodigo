using Persistencia.Contexts;
using System.Linq;
using Modelo.Cadastros;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterProdutosClassificadosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
        }

        public Produto ObterProdutoPorId(long? id)
        {
            return context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).Where(p => p.ProdutoId == id).First();
        }

        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
            } else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }


        public Produto EliminarProdutoPorId(long? id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
    }
}
