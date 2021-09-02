using ProjetoModeloDDD2.DOMINIO.ENTIDADES;
using ProjetoModeloDDD2.INFRA.DADOS.ENTIDADES_CONFIG;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD2.INFRA.DADOS.CONTEXTO
{
    public class ProjetoModeloContexto : DbContext
    {
        public ProjetoModeloContexto() : base("ProjetoModeloDDD2") // Conexão com o SQL em Web.Config.
        {
        }

        public DbSet<Cliente> Clientes { get; set; } // Tabela no banco SQL.
        public DbSet<Produto> Produtos { get; set; } // Tabela no banco SQL.

        protected override void OnModelCreating(DbModelBuilder modelBuilder) // Algumas pré-configurações necessárias.
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Remove/Evita pluralização dos nomes das tabelas pelo EF.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Remove/Evita delete em cascata de 1 para 1.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); // Remove/Evita delete em cascata de muitos para muitos.

            modelBuilder.Properties() // Define como chave primária qualquer campo com nome mais a palavra "Id", ex: "ClienteId" == chave primária.
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>() // Define para "varchar" todo campo string a ser gravado no banco SQL.
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>() // Define para "100" caracteres todo campo string a ser gravado no banco SQL.
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguracao()); // Adiciona a configuração da entidade.
            modelBuilder.Configurations.Add(new ProdutoConfiguracao()); // Adiciona a configuração da entidade.
        }

        // O campo "DataCadastro" será mantido em todas as transações de UpDate. ***
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false; // ***
                }
            }
            return base.SaveChanges();
        }

    }
}