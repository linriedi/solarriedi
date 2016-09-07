using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        public string GetArchivePath()
        {
            return this.Get("archiveLocation");
        }

        public string GetFtpUri()
        {
            return this.Get("ftpUri");
        }

        public string GetUserName()
        {
            return this.Get("userName");
        }

        private string Get(string key)
        {
            var appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var settingsPath = string.Format("{0}\\Settings.xml", appDirectory);

            return XDocument.Load(settingsPath)
                .Root
                .Elements()
                .Single(e => e.Name == key)
                .FirstAttribute.Value;            
        }
    }
}
