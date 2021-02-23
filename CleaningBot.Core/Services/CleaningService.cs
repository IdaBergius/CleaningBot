using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CleaningBot.Core.Models;

namespace CleaningBot.Core.Services
{
    public class CleaningService
    {
        public Instruction GetInstructions()
        {
            var commandList = new List<Command>() { new Command { Direction = "north", Steps = 3 }, new Command { Direction = "west", Steps = 4 }, new Command { Direction = "east", Steps = 2 } };
            var startLocation = new Location() { XCoordinate = 10, YCoordinate = 2 };

            return new Instruction() { commands = commandList, StartLocation = startLocation };
        }

        public Result Clean(Instruction instruction)
      
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            instruction = GetInstructions();
            var currentLocation = instruction.StartLocation;
            List<Location> locationList = new List<Location>();
            //currentLocation = startLocation;
            locationList.Add(currentLocation);

            foreach (var item in instruction.commands)
            {
                switch (item.Direction)
                {

                    case "north":
                        {
                            for (int i = 0; i < item.Steps; i++)
                            {
                                Location location = new Location
                                {
                                    YCoordinate = currentLocation.YCoordinate + 1,
                                    XCoordinate = currentLocation.XCoordinate
                                };
                                currentLocation = location;
                                locationList.Add(location);
                            }
                            break;
                        }

                    case "south":
                        {
                            for (int i = 0; i < item.Steps; i++)
                            {
                                Location location = new Location
                                {
                                    YCoordinate = currentLocation.YCoordinate - 1,
                                    XCoordinate = currentLocation.XCoordinate
                                };
                                currentLocation = location;
                                locationList.Add(location);
                            }
                            break;
                        }

                    case "west":
                        {
                            for (int i = 0; i < item.Steps; i++)
                            {
                                Location location = new Location
                                {
                                    XCoordinate = currentLocation.XCoordinate - 1,
                                    YCoordinate = currentLocation.YCoordinate
                                };
                                currentLocation = location;
                                locationList.Add(location);
                            }
                            break;
                        }

                    case "east":
                        {
                            for (int i = 0; i < item.Steps; i++)
                            {
                                Location location = new Location
                                {
                                    XCoordinate = currentLocation.XCoordinate + 1,
                                    YCoordinate = currentLocation.YCoordinate
                                };
                                currentLocation = location;
                                locationList.Add(location);
                            }
                            break;
                        }
                }

            }
            stopwatch.Stop();
            return new Result
            {
                NoOfCommands = locationList.Count(),
                UniqeLocationsCleaned = locationList.Distinct().Count(),
                Duration = stopwatch.Elapsed
            };
        }
    }
}


