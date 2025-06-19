using CMS.Websites.Routing;

using Microsoft.Extensions.DependencyInjection;

using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Xperience.Enrichers
{
    public class XperienceWebsiteChannelEnricher : ILogEventEnricher
    {
        private readonly IServiceProvider services;

        public XperienceWebsiteChannelEnricher(IServiceProvider services) => this.services = services;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var websiteChannelContext = services.GetRequiredService<IWebsiteChannelContext>();

            if (websiteChannelContext == null)
            {
                return; // No website channel context available, nothing to enrich
            }

            string channelName = $"{Constants.Xperience}.WebsiteChannelName";
            string channelValue = websiteChannelContext.WebsiteChannelName;

            if (!string.IsNullOrEmpty(channelValue))
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(channelName, channelValue));
            }

            string channelId = $"{Constants.Xperience}.WebsiteChannelID";
            int channelIdValue = websiteChannelContext.WebsiteChannelID;

            if (channelIdValue > 0)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(channelId, channelIdValue));
            }

            string channelPreview = $"{Constants.Xperience}.IsPreview";

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(channelPreview, websiteChannelContext.IsPreview));
        }
    }
}
