﻿using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.Options
{
    public class PreConfigureActionList<TOptions> : List<Action<TOptions>>
    {
        public void Configure(TOptions options)
        {
            foreach (var action in this)
            {
                action(options);
            }
        }

        public TOptions Configure()
        {
            var options = Activator.CreateInstance<TOptions>();
            Configure(options);
            return options;
        }
    }
}

