namespace Settings
{
    public interface ISettingsProvider
    {
        string GetArchivePath();
        string GetFtpUri();
        string GetUserName();
    }
}
