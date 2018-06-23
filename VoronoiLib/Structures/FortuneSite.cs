using System;
using System.Collections;
using System.Collections.Generic;

namespace VoronoiLib.Structures
{
    public class FortuneSite : IComparable<FortuneSite>
    {
        public Point point {get; private set;}
        public double X {
            get
            {
                return point.X;
            }
         }
        public double Y { 
            get
            {
                return point.Y;
            } 
         }
        
        public List<VEdge> Cell { get; private set; }

        public List<FortuneSite> Neighbors { get; private set; }

        public FortuneSite(double x, double y)
        {
            this.point = new Point(x, y);
            Cell = new List<VEdge>();
            Neighbors = new List<FortuneSite>();
        }

        public FortuneSite(Point point)
        {
            this.point = point;
        }

        public void ReplaceCentroid(Point point)
        {
            this.point = point;
        }

        public int CompareTo(FortuneSite site)
        {
            if(site == null) return -1;
            if(this.point.Magnitude() == site.point.Magnitude()) return 0;
            return this.point.Magnitude() > site.point.Magnitude() ? -1 : 1;
        }
    }
}
