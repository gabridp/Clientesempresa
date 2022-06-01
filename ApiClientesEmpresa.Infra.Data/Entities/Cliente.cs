﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Entities
{
    public class Cliente
    {
        #region Propriedades

        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        #endregion
    }
}
