using ApiClientesEmpresa.Infra.Data.Entities;
using ApiClientesEmpresa.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        //REGRA 2) Construtor para receber os parametros de configuração
        //que serão injetados pelo projeto AspNet API, como por exemplo
        //connectionstring etc.
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) //enviando para o construtor da superclasse.
        {

        }

        //REGRA 3) Sobrescrever o método OnModelCreating 
        //e dentro deste método
        //adicionar cada classe de mapeamento criada no projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        //REGRA 4) Para cada entidade do projeto, iremos declarar 
        //uma propriedade
        //do tipo DbSet que nos permita utilizar métodos 
        //já prontos do EF para 
        //inclusão, edição, exclusão e consulta destas entidades (CRUD)
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
