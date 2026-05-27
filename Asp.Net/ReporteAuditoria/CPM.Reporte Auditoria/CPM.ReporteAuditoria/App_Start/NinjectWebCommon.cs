[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CPM.ReporteAuditoria.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CPM.ReporteAuditoria.App_Start.NinjectWebCommon), "Stop")]



namespace CPM.ReporteAuditoria.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using CPM.ReporteAuditoria.BusinessInterface;
    using CPM.ReporteAuditoria.BusinessLayer;
    using CPM.ReporteAuditoria.DataInterface;
    using CPM.ReporteAuditoria.DataLayer;
    using CPM.ReporteAuditoria.OperationalManagement;
    using Ninject.Web.Common.WebHost;

    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
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
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuditRepository>().To<AuditRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind < IBusinessUnitRepository>().To<BusinessUnitRepository>();
            kernel.Bind<ILogger>().To<EventLogger>();
            kernel.Bind<IAuditProcessor>().To<AuditProcessor>();
            kernel.Bind<IUsuarioProcessor>().To<UsuarioProcessor>();
            kernel.Bind<IBusinessUnitProcessor>().To<BussinesUnitProcessor>();
            kernel.Bind<IExportarExcel>().To<ExportarExcelProcessor>();


        }
    }
}