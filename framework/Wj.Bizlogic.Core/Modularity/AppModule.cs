using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public abstract class AppModule : IAppModule, 
        IOnPreApplicationInitialization, IOnApplicationInitialization, IOnPostApplicationInitialization,
        IOnApplicationShutdown,
        IPreConfigureServices, IPostConfigureServices
    {
        /// <summary>
        /// 默认按照约定进行服务注册，如果要禁用它，可以设置此参数为true
        /// 默认约定见 ServiceCollectionExtensions.AddAssemblyOf
        /// </summary>
        protected internal bool SkipAutoServiceRegistration { get; protected set; }

        protected internal ServiceConfigurationContext ServiceConfigurationContext
        {
            get
            {
                if (_serviceConfigurationContext == null)
                {
                    throw new AppException($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PostConfigureServices)} methods.");
                }

                return _serviceConfigurationContext;
            }
            internal set => _serviceConfigurationContext = value;
        }

        private ServiceConfigurationContext? _serviceConfigurationContext;

        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {

        }

        public virtual Task ConfigureServicesAsync(ServiceConfigurationContext context)
        {
            ConfigureServices(context);
            return Task.CompletedTask;
        }

        public virtual Task OnPreApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            OnPreApplicationInitialization(context);
            return Task.CompletedTask;
        }

        public virtual void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            OnApplicationInitialization(context);
            return Task.CompletedTask;
        }

        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            OnPostApplicationInitialization(context);
            return Task.CompletedTask;
        }

        public virtual void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual Task OnApplicationShutdownAsync(ApplicationShutdownContext context)
        {
            OnApplicationShutdown(context);
            return Task.CompletedTask;
        }

        public virtual void OnApplicationShutdown(ApplicationShutdownContext context)
        {

        }

        public virtual Task PreConfigureServicesAsync(ServiceConfigurationContext context)
        {
            PreConfigureServices(context);
            return Task.CompletedTask;
        }

        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {

        }

        public virtual Task PostConfigureServicesAsync(ServiceConfigurationContext context)
        {
            PostConfigureServices(context);
            return Task.CompletedTask;
        }

        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {

        }

        internal static void CheckAppModuleType(Type moduleType)
        {
            if (!IsAppModule(moduleType))
            {
                throw new ArgumentException("Given type is not an APP module: " + moduleType.AssemblyQualifiedName);
            }
        }

        public static bool IsAppModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IAppModule).GetTypeInfo().IsAssignableFrom(type);
        }
    }
}
