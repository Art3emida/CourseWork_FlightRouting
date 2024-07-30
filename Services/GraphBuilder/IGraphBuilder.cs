using CourseWork_FlightRouting.Models;

namespace CourseWork_FlightRouting.Services.GraphBuilder
{
    public interface IGraphBuilder
    {
        Dictionary<string, List<string>> Build(List<Flight> flights);
    }
}