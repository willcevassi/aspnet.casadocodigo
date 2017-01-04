using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastros
{
    [Table("fabricantes")]
    public class Fabricante
    {
        [Key]
        [Column("fabricante_id")]
        public long FabricanteId { get; set; }
        [Required(ErrorMessage = "O Nome do Fabricante é obrigatório")]
        [Column("nome")]
        [StringLength(50,ErrorMessage = "Tamanho máximo de 50 caracteres excedido")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}