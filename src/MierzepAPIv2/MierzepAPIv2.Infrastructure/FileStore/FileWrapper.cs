using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MierzepAPIv2.Infrastructure.FileStore
{
    public class FileWrapper : IFileWrapper
    {
        public void WriteAllBytes(byte[] content, string outPutFile)
        {
            File.WriteAllBytes(outPutFile, content);
        }
    }
}
