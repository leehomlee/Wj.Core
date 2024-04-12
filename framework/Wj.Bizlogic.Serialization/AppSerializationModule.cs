using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.DependencyInjection;
using Wj.Bizlogic.Modularity;
using Wj.Bizlogic.Reflection;

namespace Wj.Bizlogic.Serialization
{
    public class AppSerializationModule : AppModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.OnExposing(onServiceExposingContext =>
            //{
            //    //Register types for IObjectSerializer<T> if implements
            //    onServiceExposingContext.ExposedTypes.AddRange(
            //        ReflectionHelper.GetImplementedGenericTypes(
            //            onServiceExposingContext.ImplementationType,
            //            typeof(IObjectSerializer<>)
            //        ).ConvertAll(t => new ServiceIdentifier(t))
            //    );
            //});
        }
    }
}

