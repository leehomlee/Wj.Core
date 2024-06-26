﻿using System;
using System.Threading.Tasks;

namespace Wj.Bizlogic
{
    /// <summary>
    /// This class can be used to provide an action when
    /// DisposeAsync method is called.
    /// </summary>
    public class AsyncDisposeFunc : IAsyncDisposable
    {
        private readonly Func<Task> _func;

        /// <summary>
        /// Creates a new <see cref="AsyncDisposeFunc"/> object.
        /// </summary>
        /// <param name="func">func to be executed when this object is DisposeAsync.</param>
        public AsyncDisposeFunc(Func<Task> func)
        {
            Check.NotNull(func, nameof(func));

            _func = func;
        }

        public async ValueTask DisposeAsync()
        {
            await _func();
        }
    }
}

