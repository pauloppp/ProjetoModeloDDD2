namespace ProjetoModeloDDD2.INFRA.DADOS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CONTEXTO.ProjetoModeloContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // Alterado para "true" para permitir migrações/alterações automáticas EF.
        }

        protected override void Seed(CONTEXTO.ProjetoModeloContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
