using System;

namespace VoronoiLib.Structures
{
    public class Point : IEquatable<Point>, IComparable<Point>
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

        public double Magnitude()
        {
            return Math.Abs(this.X) + Math.Abs(this.Y);
        }
        public int CompareTo(Point obj)
        {
            if(obj == null)
            {
                return -1;
            }
            
            if(this.Magnitude() > obj.Magnitude())
            {
                return -1;
            }

            return this.Magnitude() == obj.Magnitude() ? 0 : 1;
        }
    }
}
