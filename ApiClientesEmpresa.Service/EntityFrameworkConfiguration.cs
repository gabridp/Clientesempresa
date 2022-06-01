using ApiClientesEmpresa.Infra.Data.Contexts;
using ApiClientesEmpresa.Infra.Data.Interfaces;
using ApiClientesEmpresa.Infra.Data.Repositories;
using ApiEstoque.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;



namespace ApiClientesEmpresa.Service
{
    /// <summary>
    /// Classe para configuração do EntityFramework
    /// </summary>
    public class EntityFrameworkConfiguration
    {
        /// <summary>
        /// Método para registrar a configuração
        /// </summary>
        public static void Register(WebApplicationBuilder builder)
        {
            //capturar a connectionstring do banco de dados
            var connectionString = builder.Configuration
                    .GetConnectionString("ApiCliente");

            //injeção de dependencia para a classe 
            //SqlServerContext no EntityFramework

            builder.Services.AddDbContext<SqlServerContext>
                (map => map.UseSqlServer(connectionString));

            //mapear cada classe do repositorio
            builder.Services.AddTransient<IClienteRepository,
                    ClienteRepository>();

            builder.Services.AddTransient<IUsuarioRepository,
                    UsuarioRepository>();


        }
    }
}
