# GenericParser

A .NET 10 Web API for parsing generic tabular/text input (e.g. CSV) into a unified structure.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or newer
- Git

Verify your SDK version:

```bash
dotnet --version
```

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/gryszard/GenericParser.git
cd GenericParser
```

### 2. Restore dependencies

```bash
dotnet restore
```

This pulls in the project's dependencies, including `CsvHelper` and `Microsoft.AspNetCore.OpenApi`.

### 3. Run the app

```bash
dotnet run --project GenericParser/GenericParser.csproj
```

Or, from inside the `GenericParser` project folder:

```bash
cd GenericParser
dotnet run
```

By default, ASP.NET Core apps run on:

- `http://localhost:5072` (or a similar auto-assigned HTTP port)

The exact ports are listed in the console output when the app starts, and can also be found in `Properties/launchSettings.json`.

### 4. Explore the API

With `Microsoft.AspNetCore.OpenApi` enabled, the OpenAPI document is available at:

```
http://localhost:5072/openapi/v1.json
```

### 5. Example requests

```
POST http://localhost:5072/api/v1/parse-content
Content-Type: application/json
Accept: application/json
{
  "type": "CSV",
  "content": "SWQsSW1pZSxDemFzTmExMDBtCjEsUnlzemFyZCwxMC41NgoyLEphbiwKMywsMTQuOQo0LFVzYWluLDkuNTg="
}
```

```
POST http://localhost:5072/api/v1/parse-content
Content-Type: application/json
Accept: application/json
{
  "type": "INTERNAL_JSON",
  "content": "WwogewogICJNYXJrYSI6Ik9wZWwiLAogICJNb2RlbCI6IkFzdHJhIiwKICAiUm9jem5payI6IjIwMDEiCiB9LAogewogICJNYXJrYSI6IlN1enVraSIsCiAgIk1vZGVsIjoiU1g0IgogfSwKIHsKICAiTWFya2EiOiJGaWF0IiwKICAiTW9kZWwiOiJQYW5kYSIsCiAgIlNwYWxhbmllTmExMDAiOiI0LjUiCiB9Cl0="
}
```