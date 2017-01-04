using Modelo.Tabelas;
using System;
using System.ComponentModel;
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
        [StringLength(100,ErrorMessage = "O nome do produto deve ter no mímino 10 catacteres",MinimumLength =10)]
        public string Nome { get; set; }

        [DisplayName("Data	de	Cadastro")]
        [Required(ErrorMessage = "Informe a	data de	cadastro do	produto")]
        public DateTime? DataCadastro { get; set; }



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