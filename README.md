# Serilog.Enrichers.Xperience

[![NuGet](https://img.shields.io/nuget/v/Serilog.Enrichers.Xperience.svg)](https://www.nuget.org/packages/Serilog.Enrichers.Xperience)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Serilog.Enrichers.Xperience seamlessly integrates [Xperience by Kentico](https://xperience.io/) context into your Serilog logs, giving you powerful, real-time insights into user activity, site behavior, and request data. Effortlessly enhance your .NET 8 applications with actionable telemetry for monitoring, troubleshooting, and optimizing your digital experience. All with minimal configuration and maximum value.

---

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [Usage Example](#usage-example)
- [FAQ](#faq)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Xperience Contextual Data**: Enriches Serilog log events with user info, contact info, site, content type, and request data from Xperience.
- **Seamless Integration**: Easily add to existing Serilog pipelines.
- **.NET 8 Support**: Built and tested for .NET 8 applications.

---

## Installation

Install the NuGet package:

```bash
dotnet add package Serilog.Enrichers.Xperience
```

Or via the NuGet Package Manager:

```
PM> Install-Package Serilog.Enrichers.Xperience
```

---

## Requirements

- .NET 8 or later
- Xperience by Kentico

---

## Getting Started

1. Add the package to your project.
2. Configure Serilog in your application’s startup.
3. Enable the Xperience enricher.

---

## Usage Example

Here’s a basic `Program.cs` example for a .NET 8 minimal API/web app:

```csharp
using Serilog;
using Serilog.Enrichers.Xperience;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog with the Xperience enricher
builder.Host.UseSerilog((context, services, configuration) => configuration
    .Enrich.WithXperienceEnrichers(services) // <-- Add the enricher
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

// Your endpoints here

app.Run();
```

> **Note:** Ensure you have the correct Xperience dependencies and context available when using the enricher.

---

## FAQ

**Q: What versions of Xperience are supported?**  
A: The enricher targets the latest version of Xperience by Kentico. For legacy support, open an issue.

**Q: How do I verify the enricher is working?**  
A: Log an event and check the output for Xperience-specific properties (user, site, request info).

**Q: Does this work with older .NET versions?**  
A: .NET 8+ is required.

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests.  
If you have feature requests or questions, open a discussion or issue on GitHub.

**To contribute:**
- Fork this repository
- Create a feature branch
- Open a pull request describing your changes

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

_Serilog and Xperience by Kentico are trademarks of their respective owners._
