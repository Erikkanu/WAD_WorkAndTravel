namespace WAD_WorkAndTravel.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string DepAirport { get; set; }
        public string DepCity { get; set; }
        public string ArrAirport { get; set; }
        public string ArrCity { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public DateOnly DepDate { get; set; }
        public DateOnly ArrDate { get; set; }
        public int Price { get; set; }

    }
}
