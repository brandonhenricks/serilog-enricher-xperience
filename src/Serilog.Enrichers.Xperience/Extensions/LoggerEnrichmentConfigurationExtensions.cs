using Serilog.Configuration;
using Serilog.Enrichers.Xperience.Enrichers;

namespace Serilog.Enrichers.Xperience.Extensions
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
            enrichmentConfiguration.With(new XperienceWebsiteChannelEnricher(services));
            enrichmentConfiguration.With(new XperienceWebPageEnricher(services));

            return enrichmentConfiguration.With(new XperienceWebPageEnricher(services));
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

        /// <summary>
        /// Enriches log events with Xperience web page information.
        /// </summary>
        /// <param name="enrichmentConfiguration">The logger enrichment configuration.</param>
        /// <param name="services">The service provider used to resolve dependencies for the enricher.</param>
        /// <returns>The logger configuration, enriched with the Xperience web page enricher.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="enrichmentConfiguration"/> or <paramref name="services"/> is <c>null</c>.
        /// </exception>
        public static LoggerConfiguration WithXperienceWebPageEnricher(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(enrichmentConfiguration);
            ArgumentNullException.ThrowIfNull(services);
            return enrichmentConfiguration.With(new XperienceWebPageEnricher(services));
        }


        /// <summary>
        /// Enriches log events with Xperience web farm server information.
        /// </summary>
        /// <param name="enrichmentConfiguration">The logger enrichment configuration.</param>
        /// <param name="services">The service provider used to resolve dependencies for the enricher.</param>
        /// <returns>The logger configuration, enriched with the Xperience web farm server enricher.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="enrichmentConfiguration"/> or <paramref name="services"/> is <c>null</c>.
        /// </exception>s
        public static LoggerConfiguration WithXperienceWebFarmEnricher(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(enrichmentConfiguration);
            ArgumentNullException.ThrowIfNull(services);
            return enrichmentConfiguration.With(new XperienceWebFarmServerEnricher(services));
        }
    }
}
