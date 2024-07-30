using CourseWork_FlightRouting.Models;

namespace CourseWork_FlightRouting.Services.GraphBuilder
{
    public class GraphBuilder : IGraphBuilder
    {
        public Dictionary<string, List<string>> Build(List<Flight> flights)
        {
            var graph = new Dictionary<string, List<string>>();

            foreach (Flight flight in flights)
            {
                if (!graph.ContainsKey(flight.From))
                {
                    graph[flight.From] = new List<string>();
                }
                graph[flight.From].Add(flight.To);
            }

            return graph;
        }
    }
}
