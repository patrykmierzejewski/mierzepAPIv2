using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MierzepAPIv2.Infrastructure.FileStore
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
