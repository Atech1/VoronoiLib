using System;

namespace VoronoiLib.Structures
{
    public class VEdge
    {
        public Point Start { get; internal set; }
        public Point End { get; internal set; }
        public FortuneSite Left { get; }
        public FortuneSite Right { get; }
        internal double SlopeRise { get; }
        internal double SlopeRun { get; }
        internal double? Slope { get; }
        internal double? Intercept { get; }

        public VEdge Neighbor { get; internal set; }

        internal VEdge(Point start, FortuneSite left, FortuneSite right)
        {
            Start = start;
            Left = left;
            Right = right;
            
            //for bounding box edges
            if (left == null || right == null)
                return;

            //from negative reciprocal of slope of line from left to right
            //ala m = (left.y -right.y / left.x - right.x)
            SlopeRise = left.X - right.X;
            SlopeRun = -(left.Y - right.Y);
            Intercept = null;

            if (SlopeRise.ApproxEqual(0) || SlopeRun.ApproxEqual(0)) return;
            Slope = SlopeRise/SlopeRun;
            Intercept = start.Y - Slope*start.X;
        }

        public double Length()
        {
            return Math.Sqrt((Math.Pow(this.SlopeRise, 2) + Math.Pow(this.SlopeRun, 2)));
        }
    }
}
