using ApiClientesEmpresa.Infra.Data.Contexts;
using ApiClientesEmpresa.Infra.Data.Entities;
using ApiClientesEmpresa.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public ClienteRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public List<Cliente> GetAll()
        {
            return _sqlServerContext.Cliente
                .OrderBy(e => e.Nome)
                .ToList();
        }

        public void Create(Cliente entity)
        {
            _sqlServerContext.Cliente.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Cliente entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Cliente entity)
        {
            _sqlServerContext.Cliente.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public Cliente GetById(Guid id)
        {
            return _sqlServerContext.Cliente.Find(id);
        }
        public Cliente GetByEmail(string _email)
        {
            return _sqlServerContext.Cliente
                .FirstOrDefault(c => c.Email.Equals(_email));

            //return _sqlServerContext.Cliente.Find(_email);
        }
    }
}
