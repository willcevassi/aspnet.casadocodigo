﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto01.Models
{
    [Table("fabricantes")]
    public class Fabricante
    {
        [Key]
        [Column("fabricante_id")]
        public long FabricanteId { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50,ErrorMessage = "Tamanho máximo de 50 caracteres excedido")]
        public string Nome { get; set; }
    }
}