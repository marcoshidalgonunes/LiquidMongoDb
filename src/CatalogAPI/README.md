# CatalogAPI

This back-end is a Visual Studio solution adapted from [Create a web API with ASP.NET Core and MongoDB](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-5.0&tabs=visual-studio) to use [Liquid Framework](https://github.com/Avanade/Liquid-Application-Framework).

It uses [Serilog](https://github.com/serilog/serilog-aspnetcore) for logging, following the example from [ASP.NET Core 5 + Serilog](https://jkdev.me/asp-net-core-serilog/). The appSettings for Docker-Compose contains the settings to send logs and telemtry data to [Elasticsearch](https://www.elastic.co/elasticsearch/).

There is also a test project for the Service component of solution, using [xUnit with .NET Core](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test) and [Mock](https://referbruv.com/blog/posts/writing-mocking-unit-tests-in-aspnet-core-using-xunit-and-moq).
