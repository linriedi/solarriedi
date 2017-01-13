using Common;

namespace Linus.SolarRiedi.DataStoringService.Contracts
{
    public interface IReadService
    {
        void CreateReport(ReportDate date, string path);
    }
}
