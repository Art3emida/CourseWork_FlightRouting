namespace CourseWork_FlightRouting.Services.RouteFinder
{
    public interface IRouteFinder
    {
        List<List<string>> FindAllRoutes(
            Dictionary<string, List<string>> graph,
            string start,
            string destination
        );
    }
}
