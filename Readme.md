# Swagger Xml Comments

En måde at få swagger til at "Læse" dine kommentarer som er makeret med 
`<summary></summary>` samt nogle specielle tags swagger kan forstå

Kilde : https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio

## Start

### Trin 1
Start med at tilføje dette til din solution.
```xml
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>
```
Dette ville generere en dokumentationsfil med alle dine kommentarer nå koden bliver compilet.

### Trin 2

Tilføj dette til din swaggergen service options
```C#
var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
```

Du vil nu kunne se de kommentarer som du har skrevet i koden som tekst i swagger.

