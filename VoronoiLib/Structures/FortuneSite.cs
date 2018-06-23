using System.Collections.Generic;

namespace VoronoiLib.Structures
{
    public class FortuneSite
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
    }
}
