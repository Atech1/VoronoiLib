using System;
namespace VoronoiLib.Structures
{
    public class Point : IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        internal Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{this.X}, {this.Y}";
        }

        public bool Equals(Point other)
        {
            if(other == null)
            {
                return false;
            }

            return this.X == other.X && this.Y == other.Y ? true : false;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Point) ? this.Equals((Point) obj) : false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.X.GetHashCode();
            hash = (hash * 7) + this.Y.GetHashCode();
            return hash;
        }
    }
}
