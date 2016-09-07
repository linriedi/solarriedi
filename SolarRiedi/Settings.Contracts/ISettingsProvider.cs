namespace Settings.Contracts
{
    public interface ISettingsProvider
    {
        string GetArchivePath();
        string GetFtpUri();
        string GetUserName();
        string GetFilePrefix();
    }
}
