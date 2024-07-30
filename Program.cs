// Программа для поиска оптимального маршрута между двумя странами
// - существует предопределенный набор авиа-маршрутов, например самолеты летают из Германии только в Италию, из Италии могут в Нидерланды или Францию, и т.д
// - программа спрашивает у пользователя страну откуда он хочет вылететь и страну куда прилететь,
//   высчитает возможные маршруты и предоставляет все варианты с отображением количества пересадок

using CourseWork_FlightRouting.Services.GraphBuilder;
using CourseWork_FlightRouting.Services.RouteFinder;
using CourseWork_FlightRouting.Services.FlightService;
using CourseWork_FlightRouting.Services.UserInput;
using CourseWork_FlightRouting.Services.UserOutput;
using CourseWork_FlightRouting.Models;

namespace CourseWork_FlightRouting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var availableFlights = new List<Flight>
            {
                new Flight("FR", "UA"),
                new Flight("FR", "DE"),
                new Flight("DE", "IT"),
                new Flight("UA", "NL"),
                new Flight("IT", "NL"),
                new Flight("IT", "FR"),
                new Flight("IT", "UA"),
                new Flight("NL", "DE"),
            };

            IFlightService flightService = new FlightService(availableFlights);
            IGraphBuilder graphBuilder = new GraphBuilder();
            IRouteFinder routeFinder = new RouteFinder();
            IUserOutput userOutput = new ConsoleUserOutput();
            IUserInput userInput = new ConsoleUserInput(userOutput);

            var flightApplication = new FlightApp(
                flightService,
                graphBuilder,
                routeFinder,
                userInput,
                userOutput
            );
            flightApplication.Run();
        }
    }
}
