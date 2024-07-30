namespace CourseWork_FlightRouting.Services.UserInput
{
    public interface IUserInput
    {
        string GetString(string hint);
        string GetCountryCodeFromUser(string hint);
    }
}
