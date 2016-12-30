using System.Data.Entity;
using Projeto01.Models;

namespace Projeto01.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Fabricante> Fabricantes{ get; set; }

    }
}