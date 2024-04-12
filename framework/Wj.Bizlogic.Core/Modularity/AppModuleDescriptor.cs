using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Wj.Bizlogic.Modularity
{
    public class AppModuleDescriptor : IAppModuleDescriptor
    {
        public Type Type { get; }

        public Assembly Assembly { get; }

        public Assembly[] AllAssemblies { get; }

        public IAppModule Instance { get; }

        public bool IsLoadedAsPlugIn { get; }

        public IReadOnlyList<IAppModuleDescriptor> Dependencies => _dependencies.ToImmutableList();
        private readonly List<IAppModuleDescriptor> _dependencies;

        public AppModuleDescriptor(
            [NotNull] Type type,
            [NotNull] IAppModule instance,
            bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));
            AppModule.CheckAppModuleType(type);

            if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
            {
                throw new ArgumentException($"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
            }

            Type = type;
            Assembly = type.Assembly;
            AllAssemblies = AppModuleHelper.GetAllAssemblies(type);
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;

            _dependencies = new List<IAppModuleDescriptor>();
        }

        public void AddDependency(IAppModuleDescriptor descriptor)
        {
            _dependencies.AddIfNotContains(descriptor);
        }

        public override string ToString()
        {
            return $"[AppModuleDescriptor {Type.FullName}]";
        }
    }
}

