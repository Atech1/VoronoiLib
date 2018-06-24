using System.Collections.Generic;
using System.Linq;
using VoronoiLib;
using VoronoiLib.Structures;

namespace VoronoiLib
{
    public static class LoydAlgorithm
    {

        public static ICollection<FortuneSite> Loyd(ICollection<FortuneSite> Sites, int iterations)
        {
            ICollection<FortuneSite> points = Sites;
            for (int i = 0; i < iterations; i++)
            {
                points = LoydIteration(points);
            }
            return points;
            
        }
        private static ICollection<FortuneSite> LoydIteration(ICollection<FortuneSite> Sites)
        {
            List<FortuneSite> newSites = new List<FortuneSite>();
            foreach (var Site in Sites)
            {
                newSites.Add(new FortuneSite(Compute2DCentroid(Site)));
            }
            FortunesAlgorithm.Run(newSites);
            return newSites;
        }
        private static Point Compute2DCentroid(FortuneSite Site) //computes centroid to do Loyd Algorithm
        {
            var vertices = FindVertices(Site);
            if (!(vertices.Count() > 0)) return Site.point;
            double Area = 0;
            Point Centroid = new Point(0, 0);

            int i = 0;
            for (; i < Site.Cell.Count() - 1; i++)
            {
                Point current =  vertices.ElementAt(i);
                Point next = vertices.ElementAt(i + 1);
                var partialarea = current.X * next.Y - next.X * current.Y;
                Area += partialarea;
                Centroid.X += (current.X + next.X) * partialarea;
                Centroid.Y += (current.Y + next.Y) * partialarea;
            }
            
            var last = vertices.ElementAt(i);
            var first = vertices.ElementAt(0);
            var partialArea = last.X * first.Y - first.X * last.Y;
            Area += partialArea;
            Centroid.X += (first.X + last.X) * partialArea;
            Centroid.Y += (first.Y + last.Y) * partialArea;

            Area *= 0.5;
            Centroid.X /= (6.0 * Area);
            Centroid.Y /= (6.0 * Area);

            return Centroid;
        }

        private static HashSet<Point> FindVertices(FortuneSite Site) //finds all the vertices needed.
        {
             HashSet<Point> set = new HashSet<Point>();

            foreach (VEdge edge in Site.Cell)
            {
                set.Add(edge.Start);
                set.Add(edge.End);
            }
            return set;
        }
    }
}