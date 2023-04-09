using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StandBy.DTOs
{
    public class ClientesDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public bool Ativo { get;set; }

    }
}