# Copilot Instructions for Serilog.Enrichers.Xperience

## Project Overview
This is a **Serilog enricher library** that integrates **Xperience by Kentico** context into Serilog logs. The library provides enrichers that automatically add contextual data like contact information, website channels, web pages, and web farm server details to log events.

## Core Development Guidelines

### .NET & Language Standards
- Target **.NET 8 and .NET 9** (multi-targeting enabled)
- Use **C# 12** features and latest syntax where appropriate
- Enable **nullable reference types** and treat nullability warnings as errors
- Use **implicit usings** and leverage global usings for common namespaces
- Follow [Microsoft's C# coding conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

### Architecture & Design Patterns
- Follow **SOLID principles** and clean architecture patterns
- Use **dependency injection** with `IServiceProvider` for all enricher dependencies
- Keep enrichers **lightweight** and focused on single responsibilities
- Implement proper **error handling** with graceful degradation when Xperience context is unavailable
- Use **async/await** patterns where appropriate for non-blocking operations

### Serilog Enricher Patterns
- All enrichers **must implement** `ILogEventEnricher` interface
- Use `LogEvent.AddPropertyIfAbsent()` to avoid overwriting existing properties
- Create properties using `ILogEventPropertyFactory.CreateProperty()`
- Prefix all Xperience-related properties with `Constants.Xperience` namespace
- Handle null/missing context gracefully - return early if no enrichment data available
- Validate input parameters using `ArgumentNullException.ThrowIfNull()`

### Xperience by Kentico Integration
- Leverage **built-in Xperience APIs** and services through dependency injection
- Use `ICurrentContactProvider` for contact-related enrichment
- Use `IWebsiteChannelContext` for website channel information
- Use `IWebPageDataContextRetriever` for current web page context
- Use `IWebFarmService` for web farm server information
- Always check for service availability before attempting to retrieve context
- Handle scenarios where Xperience context may not be available (e.g., background services)

### Extension Methods & Configuration
- Provide fluent configuration through `LoggerEnrichmentConfiguration` extensions
- Create both individual enricher methods and combined "WithXperienceEnrichers" method
- Support method chaining for clean configuration syntax
- Include comprehensive XML documentation for all configuration methods
- Example pattern: `configuration.Enrich.WithXperienceEnrichers(services)`

### Documentation Standards
- Include **comprehensive XML documentation** for all public APIs
- Document required Xperience dependencies and setup requirements
- Provide usage examples in XML comments
- Document expected log property names and formats
- Include exception documentation for all thrown exceptions
- Update README.md for any new enrichers or configuration changes

### Performance & Error Handling
- Optimize for **minimal performance impact** on logging pipeline
- Use early returns when context is unavailable
- Avoid expensive operations in enricher implementations
- Log enricher errors to Serilog's internal logging (SelfLog) when appropriate
- Gracefully handle missing or invalid Xperience context without throwing exceptions

### Property Naming Conventions
- Use consistent property naming: `{Constants.Xperience}.{ContextType}{PropertyName}`
- Examples: `Xperience.ContactId`, `Xperience.ContactEmail`, `Xperience.WebsiteChannelName`
- Use PascalCase for property names to match .NET conventions
- Keep property names descriptive but concise

## Enricher Implementation Patterns

### Standard Enricher Structure
```csharp
public class XperienceExampleEnricher : ILogEventEnricher
{
    private readonly IServiceProvider services;
    
    public XperienceExampleEnricher(IServiceProvider services) => 
        this.services = services;
    
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var service = services.GetService<IRequiredService>();
        if (service == null) return;
        
        var contextData = service.GetContextData();
        if (contextData == null) return;
        
        logEvent.AddPropertyIfAbsent(
            propertyFactory.CreateProperty($"{Constants.Xperience}.PropertyName", contextData.Value));
    }
}
```

### Extension Method Pattern
```csharp
public static LoggerConfiguration WithXperienceExampleEnricher(
    this LoggerEnrichmentConfiguration enrichmentConfiguration,
    IServiceProvider services)
{
    ArgumentNullException.ThrowIfNull(enrichmentConfiguration);
    ArgumentNullException.ThrowIfNull(services);
    
    return enrichmentConfiguration.With(new XperienceExampleEnricher(services));
}
```

## GitHub Copilot Specific Guidelines

### Code Generation Hints
- When generating new enrichers, always start with the `ILogEventEnricher` implementation pattern
- Use the established naming convention: `Xperience{ContextType}Enricher`
- Generate corresponding extension methods for each enricher
- Include comprehensive XML documentation in generated code
- Follow the established error handling and null-checking patterns

### Common Copilot Prompts
- "Create a new enricher for [Xperience context type]"
- "Add extension method for the new enricher"
- "Generate unit tests for [enricher name]"
- "Update the combined WithXperienceEnrichers method"
- "Add XML documentation for [method/class name]"

### Code Review Checklist
- ✅ Implements `ILogEventEnricher` correctly
- ✅ Uses dependency injection through `IServiceProvider`
- ✅ Handles null/missing context gracefully
- ✅ Follows property naming conventions
- ✅ Includes comprehensive XML documentation
- ✅ Has corresponding extension method
- ✅ Includes unit tests with good coverage
- ✅ Uses `ArgumentNullException.ThrowIfNull()` for validation
- ✅ Performance optimized with early returns