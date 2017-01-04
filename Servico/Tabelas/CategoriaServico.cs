﻿using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;

namespace Servico.Tabelas
{
    public class CategoriaServico
    {

        private CategoriaDAL categoriaDAL = new CategoriaDAL();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return categoriaDAL.ObterCategoriasClassificadasPorNome();
        }

        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }

        public Categoria ObterCategoriaPorId(long? id)
        {
            return categoriaDAL.ObterCategoriaPorId(id);
        }

        public Categoria EliminarCategoriaPorId(long? id)
        {
            return categoriaDAL.EliminarCategoriaPeloId(id);
        }
    }
}
