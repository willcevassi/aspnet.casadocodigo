using Modelo.Tabelas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [Column("produto_id", Order = 0)]
        public long? ProdutoId { get; set; }
        [Column("nome_prouto")]
        [Required(ErrorMessage = "O nome do Produto é Obrigatório")]
        public string Nome { get; set; }

        [Column("fabricante_id")]
        public long? FabricanteId { get; set; }
        
        [Column("categoria_id")]
        public long? CategoriaId { get; set; }

        [Display(Name = "Fabricante")]
        public virtual Fabricante Fabricante { get; set; }
        [Display(Name = "Categoria")]
        public virtual Categoria Categoria { get; set; }
    }
}