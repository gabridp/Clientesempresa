﻿using ApiClientesEmpresa.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}
