using System;
using System.Collections.Generic;
using VoronoiLib;
using VoronoiLib.Structures;


namespace VoronoiLib
{
    public class Graph
    {
        public LinkedList<VEdge> VoronoiEdges {get; protected set;}
        public SortedSet<FortuneSite> Sites {get; protected set;}

        public Graph(ICollection<FortuneSite> Sites, double min, double max)
        {
            this.Sites = new SortedSet<FortuneSite>(Sites);
            FortunesAlgorithm.max = max;
            FortunesAlgorithm.min = min;
        }

        public void GenerateEdges()
        {
            this.VoronoiEdges = FortunesAlgorithm.Run(this.Sites);
        }

        public void LoydRelax(int iterations)
        {
            this.VoronoiEdges = LoydAlgorithm.Loyd(this.Sites, iterations, 0);
        }

        public void LoydRelax()
        {
            LoydRelax(1);
        }
    }
}