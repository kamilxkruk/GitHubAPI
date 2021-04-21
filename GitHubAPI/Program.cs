using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net.Http;

namespace GitHubAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            BuildConfig(configurationBuilder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((contect, services) =>
                {
                    services.AddHttpClient(name: "GitHub", client =>
                      {
                          client.BaseAddress = new Uri("https://api.github.com");
                          client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                          client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryExample");
                      });
                })
                .Build();
        }

        static void BuildConfig(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
