using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Common.Interfaces
{
    public interface IFileStore
    {
        string SaveWriteFile(byte[] content, string sourceFileName, string path);
    }
}
