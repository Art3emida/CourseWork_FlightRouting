using CourseWork_FlightRouting.Exceptions;

namespace CourseWork_FlightRouting.Services.RouteFinder
{
    public class RouteFinder : IRouteFinder
    {
        public List<List<string>> FindAllRoutes(
            Dictionary<string, List<string>> graph,
            string departure,
            string destination
        ) {
            if (departure == destination)
                throw new InvalidRouteException("Departure and destination cannot be the same.");

            var result = new List<List<string>>();
            var visited = new HashSet<string>();
            var path = new List<string>();

            void RecursiveSearch(string current)
            {
                if (current == destination)
                {
                    var possiblePath = new List<string>(path);
                    possiblePath.Add(current);
                    result.Add(possiblePath);
                    return;
                }

                path.Add(current);
                visited.Add(current);

                if (graph.ContainsKey(current))
                {
                    foreach (var neighbor in graph[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            RecursiveSearch(neighbor);
                        }
                    }
                }

                path.RemoveAt(path.Count - 1);

                visited.Remove(current);
            }

            RecursiveSearch(departure);
            return result;
        }
    }
}
