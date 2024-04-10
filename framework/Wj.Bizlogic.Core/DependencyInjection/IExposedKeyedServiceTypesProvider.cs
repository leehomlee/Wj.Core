using System;

namespace Wj.Bizlogic.DependencyInjection
{
    public interface IExposedKeyedServiceTypesProvider
    {
        ServiceIdentifier[] GetExposedServiceTypes(Type targetType);
    }
}

