﻿using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Wj.Bizlogic.Modularity.PlugIns
{
    public static class PlugInSourceExtensions
    {
        [NotNull]
        public static Type[] GetModulesWithAllDependencies([NotNull] this IPlugInSource plugInSource, ILogger logger)
        {
            Check.NotNull(plugInSource, nameof(plugInSource));

            return plugInSource
                .GetModules()
                .SelectMany(type => AppModuleHelper.FindAllModuleTypes(type, logger))
                .Distinct()
                .ToArray();
        }
    }
}

