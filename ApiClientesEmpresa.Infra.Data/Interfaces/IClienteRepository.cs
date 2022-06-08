using ApiClientesEmpresa.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>

    {
        List<Cliente> GetAll();
        Cliente GetByEmail(string _email);
    }
}
