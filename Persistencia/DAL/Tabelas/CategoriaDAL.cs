using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome() {
            return context.Categorias.OrderBy(c => c.Nome);
        }
        public Categoria ObterCategoriaPorId(long? id)
        {
            return context.Categorias.Where(c => c.CategoriaId == id).First();
        }

        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria EliminarCategoriaPeloId(long? id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
