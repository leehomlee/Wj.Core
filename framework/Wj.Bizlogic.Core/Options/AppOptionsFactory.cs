﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.Options
{
    public class AppOptionsFactory<TOptions> : IOptionsFactory<TOptions> where TOptions : class, new()
    {
        private readonly IConfigureOptions<TOptions>[] _setups;
        private readonly IPostConfigureOptions<TOptions>[] _postConfigures;
        private readonly IValidateOptions<TOptions>[] _validations;

        public AppOptionsFactory(
            IEnumerable<IConfigureOptions<TOptions>> setups,
            IEnumerable<IPostConfigureOptions<TOptions>> postConfigures)
            : this(setups, postConfigures, validations: Array.Empty<IValidateOptions<TOptions>>())
        {

        }

        public AppOptionsFactory(
            IEnumerable<IConfigureOptions<TOptions>> setups,
            IEnumerable<IPostConfigureOptions<TOptions>> postConfigures,
            IEnumerable<IValidateOptions<TOptions>> validations)
        {
            _setups = setups as IConfigureOptions<TOptions>[] ?? new List<IConfigureOptions<TOptions>>(setups).ToArray();
            _postConfigures = postConfigures as IPostConfigureOptions<TOptions>[] ?? new List<IPostConfigureOptions<TOptions>>(postConfigures).ToArray();
            _validations = validations as IValidateOptions<TOptions>[] ?? new List<IValidateOptions<TOptions>>(validations).ToArray();
        }

        public virtual TOptions Create(string name)
        {
            var options = CreateInstance(name);

            ConfigureOptions(name, options);
            PostConfigureOptions(name, options);
            ValidateOptions(name, options);

            return options;
        }

        protected virtual void ConfigureOptions(string name, TOptions options)
        {
            foreach (var setup in _setups)
            {
                if (setup is IConfigureNamedOptions<TOptions> namedSetup)
                {
                    namedSetup.Configure(name, options);
                }
                else if (name == Microsoft.Extensions.Options.Options.DefaultName)
                {
                    setup.Configure(options);
                }
            }
        }

        protected virtual void PostConfigureOptions(string name, TOptions options)
        {
            foreach (var post in _postConfigures)
            {
                post.PostConfigure(name, options);
            }
        }

        protected virtual void ValidateOptions(string name, TOptions options)
        {
            if (_validations.Length <= 0)
            {
                return;
            }

            var failures = new List<string>();
            foreach (var validate in _validations)
            {
                var result = validate.Validate(name, options);
                if (result.Failed)
                {
                    failures.AddRange(result.Failures);
                }
            }
            if (failures.Count > 0)
            {
                throw new OptionsValidationException(name, typeof(TOptions), failures);
            }
        }

        protected virtual TOptions CreateInstance(string name)
        {
            return Activator.CreateInstance<TOptions>();
        }
    }
}

