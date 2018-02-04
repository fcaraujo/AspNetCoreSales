using System;
using System.IO;

namespace ANC.Sales.Commom.Wrappers
{
    public interface ICsvWritterWrapper : IDisposable
    {
        FileInfo Write();
    }
}
