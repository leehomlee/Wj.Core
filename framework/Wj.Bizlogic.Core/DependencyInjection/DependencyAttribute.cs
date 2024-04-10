using Microsoft.Extensions.DependencyInjection;
using System;

namespace Wj.Bizlogic.DependencyInjection
{
    /// <summary>
    /// 依赖注入特性
    /// </summary>
    public class DependencyAttribute : Attribute
    {
        /// <summary>
        /// 注册的生命周期 Singleton、Transient、Scoped
        /// </summary>
        public virtual ServiceLifetime? Lifetime { get; set; }
        /// <summary>
        /// 设置true则只注册之前未注册的服务 IServiceCollection.TryAdd
        /// </summary>
        public virtual bool TryRegister { get; set; }
        /// <summary>
        /// 设置true则替换之前已注册的服务   IServiceCollection.Replace
        /// </summary>
        public virtual bool ReplaceServices { get; set; }

        public DependencyAttribute()
        {

        }

        public DependencyAttribute(ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
        }
    }
}

