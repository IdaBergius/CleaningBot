using System;
using CleaningBot.Core.Services;
using CleaningBot.Core.Models;

namespace CleaningBot.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var cleaningService = new CleaningService();
            var instructions = new Instruction();
            var result = cleaningService.Clean(instructions);

            Console.WriteLine(@$"Result from the cleaning: noOfCommands: {result.NoOfCommands}, uniqueSpotsCleaned: {result.UniqeLocationsCleaned}");
        }
    }
}
