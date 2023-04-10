using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StandBy.Models
{
    public class Produtos
    {
        public int Id { get; set; }

        [Display(Name="Código")]
        [Required]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        [Required]
        [Range(1,999)]
        public int QuantidadeEstoque { get; set; }

        [Required]
        [Range(0.1, 999)]
        public decimal Valor { get; set; }
    }
}