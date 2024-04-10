﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Wj.Bizlogic.DependencyInjection
{
    public interface IConventionalRegistrar
    {
        void AddAssembly(IServiceCollection services, Assembly assembly);

        void AddTypes(IServiceCollection services, params Type[] types);

        void AddType(IServiceCollection services, Type type);
    }
}

