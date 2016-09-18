using System.IO;

namespace Linus.SolarRiedi.AzureStorageWrapper.Contracts
{
    public interface IAzureStorage
    {
        void Init(string container);
        void UploadFromStream(Stream stream, string fileName);
    }
}
