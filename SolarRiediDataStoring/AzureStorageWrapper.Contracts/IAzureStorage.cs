using System.Collections.Generic;
using System.IO;

namespace Linus.SolarRiedi.AzureStorageWrapper.Contracts
{
    public interface IAzureStorage
    {
        void UploadFromStream(Stream stream, string containerName, string fileName);
        IEnumerable<string> GetAllFiles(string containerName, string filePrefix);
        string GetCsvAsString(string fileName);
    }
}
