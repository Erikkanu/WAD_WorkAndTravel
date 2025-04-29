using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;
using System.Linq;
using System.Collections.Generic;
using System;

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

        public IEnumerable<Ticket> SearchTickets(string origin, string destination, DateOnly? departure, DateOnly? returnDate)
        {
            var query = _repository.Ticket.FindAll();

            if (!string.IsNullOrEmpty(origin))
            {
                query = query.Where(t => t.DepCity.Contains(origin) || t.DepAirport.Contains(origin));
            }

            if (!string.IsNullOrEmpty(destination))
            {
                query = query.Where(t => t.ArrCity.Contains(destination) || t.ArrAirport.Contains(destination));
            }

            if (departure.HasValue)
            {
                query = query.Where(t => t.DepDate == departure.Value);
            }

            if (returnDate.HasValue)
            {
                query = query.Where(t => t.ArrDate == returnDate.Value);
            }

            return query.ToList();
        }
    }
}