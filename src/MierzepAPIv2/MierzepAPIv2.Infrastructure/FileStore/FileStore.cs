using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MierzepAPIv2.Infrastructure.FileStore
{
    /// <summary>
    /// File store for file. 
    /// </summary>
    public class FileStore : IFileStore
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly IDirectoryWrapper _directoryWrapper;
        
        public FileStore(IFileWrapper fileWrapper, IDirectoryWrapper directoryWrapper)
        {
            _fileWrapper = fileWrapper;
            _directoryWrapper = directoryWrapper;
        }

        public string SaveWriteFile(byte[] content, string sourceFileName, string path)
        {
            _directoryWrapper.CreateDirectory(path);

            var outPutFile = Path.Combine(path, sourceFileName);
            _fileWrapper.WriteAllBytes(content, outPutFile);

            return outPutFile;
        }

        
    }
}
