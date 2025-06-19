using CMS.ContactManagement;

using Microsoft.Extensions.DependencyInjection;

using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Xperiencey.Enrichers
{
    public class XperienceContactEnricher : ILogEventEnricher
    {
        private readonly IServiceProvider services;

        public XperienceContactEnricher(IServiceProvider services) => this.services = services;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            // Implementation for enriching log events with Xperience contact information
            // This could include adding properties like ContactId, ContactEmail, etc.
            var currentContactProvider = services.GetRequiredService<ICurrentContactProvider>();

            if (currentContactProvider == null)
            {
                return; // No current contact provider available, nothing to enrich
            }

            var currentContact = currentContactProvider.GetCurrentContact();

            if (currentContact == null)
            {
                return; // No contact available, nothing to enrich
            }

            string contactId = $"{Constants.Xperience}.ContactId";
            int contactIdValue = currentContact.ContactID;

            if (contactIdValue > 0)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(contactId, contactIdValue));
            }

            string contactEmail = $"{Constants.Xperience}.ContactEmail";
            string contactEmailValue = currentContact.ContactEmail;

            if (!string.IsNullOrEmpty(contactEmailValue))
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(contactEmail, contactEmailValue));
            }
        }
    }
}
