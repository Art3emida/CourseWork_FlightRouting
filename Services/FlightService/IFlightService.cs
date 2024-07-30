using CourseWork_FlightRouting.Models;

namespace CourseWork_FlightRouting.Services.FlightService
{
    public interface IFlightService
    {
        List<Flight> GetAvailableFlights();
    }
}
