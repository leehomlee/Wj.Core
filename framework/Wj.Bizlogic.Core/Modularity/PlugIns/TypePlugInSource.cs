﻿using JetBrains.Annotations;
using System;

namespace Wj.Bizlogic.Modularity.PlugIns
{
    public class TypePlugInSource : IPlugInSource
    {
        private readonly Type[] _moduleTypes;

        public TypePlugInSource(params Type[]? moduleTypes)
        {
            _moduleTypes = moduleTypes ?? new Type[0];
        }

        [NotNull]
        public Type[] GetModules()
        {
            return _moduleTypes;
        }
    }
}

