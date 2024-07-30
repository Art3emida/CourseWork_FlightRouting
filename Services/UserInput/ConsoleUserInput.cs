using CourseWork_FlightRouting.Services.UserOutput;

namespace CourseWork_FlightRouting.Services.UserInput
{
    public class ConsoleUserInput : IUserInput
    {
        private readonly IUserOutput _userOutput;

        public ConsoleUserInput(IUserOutput userOutput)
        {
            _userOutput = userOutput;
        }

        public string GetString(string hint)
        {
            _userOutput.ShowMessage(hint);
            return Console.ReadLine() ?? "";
        }

        public string GetCountryCodeFromUser(string hint)
        {
            string input;

            do
            {
                _userOutput.ShowMessage(hint);
                input = Console.ReadLine() ?? "";

                try
                {
                    if (string.IsNullOrEmpty(input))
                        throw new ArgumentException("Input cannot be empty.");
                    else if (input.Length != 2)
                        throw new ArgumentException("Input must be exactly two characters long.");
                    else
                        foreach (char c in input)
                            if (!char.IsLetter(c))
                                throw new ArgumentException("Input must contain only letters.");

                    break;
                }
                catch (ArgumentException ex)
                {
                    _userOutput.ShowMessage(ex.Message);
                }
            }
            while (true);

            return input.ToUpper();
        }
    }
}
