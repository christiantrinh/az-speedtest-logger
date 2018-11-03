using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpeedTestLogger
{
    public class LoggerConfiguration
    {
        // Code continues here
        public readonly RegionInfo LoggerLocation;
        public readonly string UserId;
        public readonly int LoggerId;
        public readonly Uri ApiUrl;

    public LoggerConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = builder.Build();
                ApiUrl = new Uri(configuration["speedTestApiUrl"]);


        var countryCode = configuration["loggerLocationCountryCode"];
        LoggerLocation = new RegionInfo(countryCode);

        Console.WriteLine("Logger located in {0}", LoggerLocation.EnglishName);
        UserId = configuration["userId"];
        LoggerId = Int32.Parse(configuration["loggerId"]);

    }
    }
}