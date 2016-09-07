using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
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
            var location = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            var settingsPath = path + "\\Settings.xml";

            var doc = XDocument.Load(settingsPath);
            var authors = doc
                .Root
                .Elements()
                .Single(e => e.Name == key);

            return authors.FirstAttribute.Value;            
        }
    }
}
