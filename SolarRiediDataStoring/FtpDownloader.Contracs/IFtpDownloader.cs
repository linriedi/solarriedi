namespace Linus.SolarRiedi.FtpDownloader.Contracs
{
    public interface IFtpDownloader
    {
        void DownLoad(string targedPath, string filePrefix);
        void DownLoadOfLastFourDays(string targedPath, string filePrefix);
    }
}
