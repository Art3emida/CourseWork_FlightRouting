namespace CourseWork_FlightRouting.Models
{
    public record Flight(string From, string To)
    {
        public override string ToString()
        {
            return $"{From} -> {To}";
        }
    }
}
