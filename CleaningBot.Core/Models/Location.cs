using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningBot.Core.Models
{
    public class Location : IEquatable<Location>
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public bool Equals([AllowNull] Location other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return XCoordinate.Equals(other.XCoordinate) && YCoordinate.Equals(other.YCoordinate);
        }

        public override int GetHashCode()
        {
            int hashX = XCoordinate.GetHashCode();

            int hashY = YCoordinate.GetHashCode();

            return hashX ^ hashY;
        }
    }
}
