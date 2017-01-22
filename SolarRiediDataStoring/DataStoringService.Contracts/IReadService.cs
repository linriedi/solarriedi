using System.Threading.Tasks;

namespace Linus.SolarRiedi.DataStoringService.Contracts
{
    public interface IReadService
    {
        Task CreateReport(string date, string path);
        Task CreateFullReport(string path);
    }
}
