using CourseWork_FlightRouting.Models;

namespace CourseWork_FlightRouting.Services.FlightService
{
    public class FlightService : IFlightService
    {
        private readonly List<Flight> _availableFlights;

        public FlightService(List<Flight> availableFlights)
        {
            _availableFlights = availableFlights;
        }

        public List<Flight> GetAvailableFlights() => _availableFlights;
    }
}
