using System;

namespace VoronoiLib.Structures
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        internal Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{this.X}, {this.Y}";
        }
    }
}
