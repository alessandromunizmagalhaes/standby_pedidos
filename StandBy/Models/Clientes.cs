using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StandBy.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name="CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        public bool Ativo { get;set; }

        public Clientes() 
        {
            Ativo = true;
        }
    }
}