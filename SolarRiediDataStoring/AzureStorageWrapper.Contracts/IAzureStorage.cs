using System.Collections.Generic;
using System.IO;

namespace Linus.SolarRiedi.AzureStorageWrapper.Contracts
{
    public interface IAzureStorage
    {
        void Init(string container);
        void UploadFromStream(Stream stream, string fileName);
        void GetStream(string fileName, Stream stream);
        IEnumerable<string> GetAllFiles();
    }
}
