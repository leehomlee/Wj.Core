using System;
using System.IO;

namespace Wj.Bizlogic.Content
{
    public interface IRemoteStreamContent : IDisposable
    {
        string? FileName { get; }

        string ContentType { get; }

        long? ContentLength { get; }

        Stream GetStream();
    }
}

