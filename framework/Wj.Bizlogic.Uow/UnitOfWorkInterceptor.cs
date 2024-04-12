using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Wj.Bizlogic.DependencyInjection;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.Uow
{
    public class UnitOfWorkInterceptor : AppInterceptor, ITransientDependency
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UnitOfWorkInterceptor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public override async Task InterceptAsync(IAppMethodInvocation invocation)
        {
            if (!UnitOfWorkHelper.IsUnitOfWorkMethod(invocation.Method, out var unitOfWorkAttribute))
            {
                await invocation.ProceedAsync();
                return;
            }

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var options = CreateOptions(scope.ServiceProvider, invocation, unitOfWorkAttribute);

                var unitOfWorkManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

                //Trying to begin a reserved UOW by AbpUnitOfWorkMiddleware
                if (unitOfWorkManager.TryBeginReserved(UnitOfWork.UnitOfWorkReservationName, options))
                {
                    await invocation.ProceedAsync();

                    if (unitOfWorkManager.Current != null)
                    {
                        await unitOfWorkManager.Current.SaveChangesAsync();
                    }

                    return;
                }

                using (var uow = unitOfWorkManager.Begin(options))
                {
                    await invocation.ProceedAsync();
                    await uow.CompleteAsync();
                }
            }
        }

        private AppUnitOfWorkOptions CreateOptions(IServiceProvider serviceProvider, IAppMethodInvocation invocation, UnitOfWorkAttribute? unitOfWorkAttribute)
        {
            var options = new AppUnitOfWorkOptions();

            unitOfWorkAttribute?.SetOptions(options);

            if (unitOfWorkAttribute?.IsTransactional == null)
            {
                var defaultOptions = serviceProvider.GetRequiredService<IOptions<AppUnitOfWorkDefaultOptions>>().Value;
                options.IsTransactional = defaultOptions.CalculateIsTransactional(
                    autoValue: serviceProvider.GetRequiredService<IUnitOfWorkTransactionBehaviourProvider>().IsTransactional
                               ?? !invocation.Method.Name.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase)
                );
            }

            return options;
        }
    }
}

