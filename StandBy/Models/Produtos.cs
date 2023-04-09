﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandBy.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
    }
}