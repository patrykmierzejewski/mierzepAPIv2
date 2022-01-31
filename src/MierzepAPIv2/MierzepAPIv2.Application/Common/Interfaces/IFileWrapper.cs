using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Common.Interfaces
{
    public interface IFileWrapper
    {
        void WriteAllBytes(byte[] content, string outPutFile);
    }
}
