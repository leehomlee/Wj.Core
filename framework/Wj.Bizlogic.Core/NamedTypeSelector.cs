﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Wj.Bizlogic
{
    public class NamedTypeSelector
    {
        /// <summary>
        /// Name of the selector.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Predicate.
        /// </summary>
        public Func<Type, bool> Predicate { get; set; }

        /// <summary>
        /// Creates new <see cref="NamedTypeSelector"/> object.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="predicate">Predicate</param>
        public NamedTypeSelector(string name, Func<Type, bool> predicate)
        {
            Name = name;
            Predicate = predicate;
        }
    }
    public static class NamedTypeSelectorListExtensions
    {
        /// <summary>
        /// Add list of types to the list.
        /// </summary>
        /// <param name="list">List of NamedTypeSelector items</param>
        /// <param name="name">An arbitrary but unique name (can be later used to remove types from the list)</param>
        /// <param name="types"></param>
        public static void Add(this IList<NamedTypeSelector> list, string name, params Type[] types)
        {
            Check.NotNull(list, nameof(list));
            Check.NotNull(name, nameof(name));
            Check.NotNull(types, nameof(types));

            list.Add(new NamedTypeSelector(name, type => types.Any(type.IsAssignableFrom)));
        }
    }
}

