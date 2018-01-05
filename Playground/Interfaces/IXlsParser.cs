using System;
using System.IO;

namespace Playground.Interfaces
{
    public interface IXlsParser
    {
        object Parse(Stream s);
    }
}
