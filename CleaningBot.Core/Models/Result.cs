using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningBot.Core.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int NoOfCommands { get; set; }
        public int UniqeLocationsCleaned { get; set; }
        public DateTime Timestamp { get; set; }
        public TimeSpan Duration { get; set; 
        }
    }
}
