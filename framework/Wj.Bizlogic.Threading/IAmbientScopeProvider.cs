﻿namespace Wj.Bizlogic.Threading
{
    public interface IAmbientScopeProvider<T>
    {
        T? GetValue(string contextKey);

        IDisposable BeginScope(string contextKey, T value);
    }
}

