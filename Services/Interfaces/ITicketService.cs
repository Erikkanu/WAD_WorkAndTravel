using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void CreateTicket(Ticket Ticket);
        void UpdateTicket(Ticket Ticket);
        void DeleteTicket(Ticket Ticket);
        IEnumerable<Ticket> SearchTickets(string origin, string destination, DateOnly? departure, DateOnly? returnDate);
    }
}
