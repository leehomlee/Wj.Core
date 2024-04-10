using System;

namespace Wj.Bizlogic.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class DisablePropertyInjectionAttribute : Attribute
    {

    }
}

