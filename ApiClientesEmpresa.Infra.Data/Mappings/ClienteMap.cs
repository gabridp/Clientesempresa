using ApiClientesEmpresa.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientesEmpresa.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Cliente
    /// </summary>
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");
            //mapear o campo chave primária
            builder.HasKey(e => e.IdCliente);
            //mapear cada campo da tabela
            builder.Property(e => e.IdCliente)
                .HasColumnName("IDCLIENTE");

            builder.Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(e => e.DataNascimento)
                .HasColumnName("DATACNASCIMENTO")
                .IsRequired();


        }
    }
}
