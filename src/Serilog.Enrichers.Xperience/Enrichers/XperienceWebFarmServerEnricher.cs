using CMS.Core;

using Microsoft.Extensions.DependencyInjection;

using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Xperience.Enrichers
{
    public class XperienceWebFarmServerEnricher : ILogEventEnricher
    {
        private readonly IServiceProvider services;

        public XperienceWebFarmServerEnricher(IServiceProvider services) => this.services = services ?? throw new ArgumentNullException(nameof(services));

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var webFarmService = services.GetRequiredService<IWebFarmService>();

            if (webFarmService == null)
            {
                return; // No web farm service available, nothing to enrich
            }

            string serverName = $"{Constants.Xperience}.WebFarmServerName";
            string serverNameValue = webFarmService.ServerName;

            if (!string.IsNullOrEmpty(serverNameValue))
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(serverName, serverNameValue));
            }

            string webFarmEnabled = $"{Constants.Xperience}.WebFarmEnabled";
            bool isWebFarmEnabled = webFarmService.WebFarmEnabled;

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(webFarmEnabled, isWebFarmEnabled));
        }
    }
}
