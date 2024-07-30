using CourseWork_FlightRouting.Exceptions;
using CourseWork_FlightRouting.Models;
using CourseWork_FlightRouting.Services.FlightService;
using CourseWork_FlightRouting.Services.GraphBuilder;
using CourseWork_FlightRouting.Services.RouteFinder;
using CourseWork_FlightRouting.Services.UserInput;
using CourseWork_FlightRouting.Services.UserOutput;

namespace CourseWork_FlightRouting
{
    public class FlightApp
    {
        private readonly IFlightService _flightService;
        private readonly IGraphBuilder _graphBuilder;
        private readonly IRouteFinder _routeFinder;
        private readonly IUserInput _userInput;
        private readonly IUserOutput _userOutput;

        public FlightApp(
            IFlightService flightService,
            IGraphBuilder graphBuilder,
            IRouteFinder routeFinder,
            IUserInput userInput,
            IUserOutput userOutput
        ) {
            _flightService = flightService;
            _graphBuilder = graphBuilder;
            _routeFinder = routeFinder;
            _userInput = userInput;
            _userOutput = userOutput;
        }

        public void Run()
        {
            ShowAvailableFlights();

            while (true)
            {
                LaunchHelper();

                var exitChoice = _userInput.GetString("\nDo you wish to continue? Press Enter to proceed, or type any other character to exit.");
                if (!String.IsNullOrEmpty(exitChoice))
                    break;
            }
        }

        private void LaunchHelper()
        {
            string departure = _userInput.GetCountryCodeFromUser("Enter the departure point: (for example, IT)");
            string destination = _userInput.GetCountryCodeFromUser("Enter the destination point: (for example, UA)");

            try
            {
                var possibleRoutes = GetPossibleRoutes(departure, destination);
                if (possibleRoutes.Count == 0)
                    throw new InvalidOperationException("No suitable flights available.");

                _userOutput.ShowMessage("Possible routes:");
                foreach (List<string> route in possibleRoutes)
                {
                    int layovers = route.Count - 2;
                    _userOutput.ShowMessage($"{string.Join(" -> ", route)} | layovers: {layovers}");
                }
            }
            catch (InvalidRouteException ex)
            {
                _userOutput.ShowMessage(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _userOutput.ShowMessage(ex.Message);
            }
        }

        private void ShowAvailableFlights()
        {
            _userOutput.ShowMessage("Available flights:");
            foreach (Flight flight in _flightService.GetAvailableFlights())
            {
                _userOutput.ShowMessage(flight.ToString());
            }
            _userOutput.ShowMessage("-------------");
        }

        private List<List<string>> GetPossibleRoutes(string departure, string destination)
        {
            var graph = _graphBuilder.Build(_flightService.GetAvailableFlights());
            var routesResult = _routeFinder.FindAllRoutes(graph, departure, destination);
            return routesResult.OrderBy(r => r.Count).ToList();
        }
    }
}
