using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningBot.Core.Models
{
    public class Instruction
    {
        public List<Command> commands { get; set; }

        public Location StartLocation { get; set; }

    }
}
