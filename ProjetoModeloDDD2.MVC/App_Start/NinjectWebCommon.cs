[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoModeloDDD2.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoModeloDDD2.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoModeloDDD2.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ProjetoModeloDDD2.APLICACAO;
    using ProjetoModeloDDD2.APLICACAO.INTERFACES;
    using ProjetoModeloDDD2.DOMINIO.INTERFACES.REPOSITORIOS;
    using ProjetoModeloDDD2.DOMINIO.INTERFACES.SERVICOS;
    using ProjetoModeloDDD2.DOMINIO.SERVICOS;
    using ProjetoModeloDDD2.INFRA.DADOS.REPOSITORIOS;

    public static class NinjectWebCommon // Container de Injeção de Dependências.
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) // Este método do container resolve todas as injeções de dependência para o projeto.
        {
            kernel.Bind(typeof(IAppServicoBase<>)).To(typeof(AppServicoBase<>));
            kernel.Bind<IClienteAppServico>().To<ClienteAppServico>();
            kernel.Bind<IProdutoAppServico>().To<ProdutoAppServico>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<IClienteServico>().To<ClienteServico>();
            kernel.Bind<IProdutoServico>().To<ProdutoServico>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<IClienteRepositorio>().To<ClienteRepositorio>();
            kernel.Bind<IProdutoRepositorio>().To<ProdutoRepositorio>();


        }
    }
}