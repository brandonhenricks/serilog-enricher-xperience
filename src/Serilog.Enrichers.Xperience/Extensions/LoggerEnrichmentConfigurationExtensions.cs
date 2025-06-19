using Serilog.Configuration;
using Serilog.Enrichers.Xperiencey.Enrichers;

namespace Serilog.Enrichers.Xperiencey.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="LoggerEnrichmentConfiguration"/> to add Xperience enrichers.
    /// </summary>
    public static class LoggerEnrichmentConfigurationExtensions
    {
        /// <summary>
        /// Enriches log events with Xperience-specific properties, including contact and website channel information.
        /// </summary>
        /// <param name="enrichmentConfiguration">The logger enrichment configuration.</param>
        /// <param name="services">The service provider used to resolve dependencies for enrichers.</param>
        /// <returns>The logger configuration, enriched with Xperience enrichers.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="enrichmentConfiguration"/> or <paramref name="services"/> is <c>null</c>.
        /// </exception>
        public static LoggerConfiguration WithXperienceEnrichers(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(enrichmentConfiguration);
            ArgumentNullException.ThrowIfNull(services);

            enrichmentConfiguration.With(new XperienceContactEnricher(services));

            return enrichmentConfiguration.With(new XperienceWebsiteChannelEnricher(services));
        }

        /// <summary>
        /// Enriches log events with Xperience contact information.
        /// </summary>
        /// <param name="enrichmentConfiguration">The logger enrichment configuration.</param>
        /// <param name="services">The service provider used to resolve dependencies for the enricher.</param>
        /// <returns>The logger configuration, enriched with the Xperience contact enricher.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="enrichmentConfiguration"/> or <paramref name="services"/> is <c>null</c>.
        /// </exception>
        public static LoggerConfiguration WithXperienceContactEnricher(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(enrichmentConfiguration);
            ArgumentNullException.ThrowIfNull(services);

            return enrichmentConfiguration.With(new XperienceContactEnricher(services));
        }

        /// <summary>
        /// Enriches log events with Xperience website channel information.
        /// </summary>
        /// <param name="enrichmentConfiguration">The logger enrichment configuration.</param>
        /// <param name="services">The service provider used to resolve dependencies for the enricher.</param>
        /// <returns>The logger configuration, enriched with the Xperience website channel enricher.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="enrichmentConfiguration"/> or <paramref name="services"/> is <c>null</c>.
        /// </exception>
        public static LoggerConfiguration WithXperienceWebsiteChannelEnricher(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(enrichmentConfiguration);
            ArgumentNullException.ThrowIfNull(services);

            return enrichmentConfiguration.With(new XperienceWebsiteChannelEnricher(services));
        }
    }
}
