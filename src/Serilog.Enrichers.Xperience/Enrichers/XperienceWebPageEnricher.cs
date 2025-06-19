using Kentico.Content.Web.Mvc;

using Microsoft.Extensions.DependencyInjection;

using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Xperience.Enrichers
{
    public class XperienceWebPageEnricher : ILogEventEnricher
    {
        private readonly IServiceProvider services;

        public XperienceWebPageEnricher(IServiceProvider services) => this.services = services ?? throw new ArgumentNullException(nameof(services));

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var pageRetriever = services.GetService<IWebPageDataContextRetriever>();

            if (pageRetriever == null)
            {
                return; // No page retriever available, nothing to enrich
            }

            var pageDataContext = pageRetriever.Retrieve();

            if (pageDataContext == null)
            {
                return; // No page data context available, nothing to enrich
            }

            string pageId = $"{Constants.Xperience}.WebPageItemID";
            int pageIdValue = pageDataContext.WebPage.WebPageItemID;

            if (pageIdValue > 0)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(pageId, pageIdValue));
            }

            string contentTypeName = $"{Constants.Xperience}.ContentTypeName";
            string contentTypeNameValue = pageDataContext.WebPage.ContentTypeName;

            if (!string.IsNullOrEmpty(contentTypeNameValue))
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(contentTypeName, contentTypeNameValue));
            }

            string languageName = $"{Constants.Xperience}.LanguageName";
            string languageNameValue = pageDataContext.WebPage.LanguageName;

            if (!string.IsNullOrEmpty(languageNameValue))
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(languageName, languageNameValue));
            }
        }
    }
}
