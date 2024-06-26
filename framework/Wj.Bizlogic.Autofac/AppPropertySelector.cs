﻿using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Autofac
{
    public class AppPropertySelector : DefaultPropertySelector
    {
        public AppPropertySelector(bool preserveSetValues) : base(preserveSetValues)
        {
        }

        public override bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.GetCustomAttributes(typeof(DisablePropertyInjectionAttribute), true).IsNullOrEmpty() &&
                   base.InjectProperty(propertyInfo, instance);
        }
    }
}

