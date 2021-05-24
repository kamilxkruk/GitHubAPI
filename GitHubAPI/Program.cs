using GitHubAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using GitHubAPI.Model.JsonResponse;
using Newtonsoft.Json;

namespace GitHubAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            BuildConfig(configurationBuilder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient(name: "GitHub", client =>
                      {
                          client.BaseAddress = new Uri("https://api.github.com");
                          client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                          client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryExample");
                      });
                    services.AddTransient<IGitHubService, GitHubService>();
                    services.AddAutoMapper(typeof(Program));
                })
                .Build();

            var gitHubService = ActivatorUtilities.CreateInstance<GitHubService>(host.Services);
            await PerformAppFlow(gitHubService);

        }


        static void BuildConfig(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }

        static async Task PerformAppFlow(GitHubService gitHubService)
        {
            Console.WriteLine("Witaj w konsolowej aplikacji do obługi API GitHub!");
            Console.WriteLine(@"Menu:
1. Informacje o użytkowniku
2. Wyjście
");

            var userChoice = Console.ReadKey().Key;

            if (userChoice == ConsoleKey.D1)
            {
                Console.WriteLine("Wpisz nazwę użytkownika którą chcesz sprawdzić: ");
                var username = Console.ReadLine();
                var userInfo = await gitHubService.GetUserInfoAsync(username.Trim().ToLower());
                Console.WriteLine("\n"+userInfo);
            }

        }

    }
}
