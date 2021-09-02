using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.INFRA.DADOS.ENTIDADES_CONFIG
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            HasKey(c => c.ClienteId);
            Property(c => c.Nome).IsRequired().HasMaxLength(150);
            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);
            Property(c => c.Email).IsRequired();

        }

    }
}