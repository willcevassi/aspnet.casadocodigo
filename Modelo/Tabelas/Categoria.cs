using Modelo.Cadastros;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Tabelas
{
    public class Categoria
    {
        [Key]
        [Column("categoria_id",Order = 0)]
        public long? CategoriaId { get; set; }
        [Column("Nome",Order = 1)]
        [StringLength(80,ErrorMessage = "Tammanho máximo de 80 caracteres excedido.")]
        [Required(ErrorMessage = "O Nome da categoria é obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}