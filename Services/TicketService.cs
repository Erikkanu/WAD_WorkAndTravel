using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;

namespace WAD_WorkAndTravel.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepositoryWrapper _repository;

        public TicketService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _repository.Ticket.FindAll().ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _repository.Ticket.FindByCondition(j => j.TicketID == id).FirstOrDefault();
        }

        public void CreateTicket(Ticket Ticket)
        {
            _repository.Ticket.Create(Ticket);
            _repository.Save();
        }

        public void UpdateTicket(Ticket Ticket)
        {
            _repository.Ticket.Update(Ticket);
            _repository.Save();
        }

        public void DeleteTicket(Ticket Ticket)
        {
            _repository.Ticket.Delete(Ticket);
            _repository.Save();
        }
    }
}
