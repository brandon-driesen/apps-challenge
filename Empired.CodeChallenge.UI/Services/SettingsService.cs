using System.Collections.Generic;
using System.Collections.Specialized;
using Empired.CodeChallenge.UI.Interfaces;

namespace Empired.CodeChallenge.UI.Services
{
    public class SettingsService : ISettingsService
    {

        public static class DefaultSettings
        {
            public static readonly KeyValuePair<string, string> ConnectionString = new KeyValuePair<string, string>(nameof(ConnectionString), "Initial Catalog=Animals;Data Source=.;Trusted_Connection=True;");
        }

        private readonly NameValueCollection _settings;

        public SettingsService(NameValueCollection settings)
        {
            _settings = settings;
        }

        public string ConnectionString => _settings.GetValueOrDefault(DefaultSettings.ConnectionString);

    }
}
