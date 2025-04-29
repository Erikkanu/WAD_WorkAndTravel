using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Services;

namespace WAD_WorkAndTravel.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            var tickets = _ticketService.GetAllTickets();
            return View(tickets);
        }

        // GET: Tickets/Search
        public IActionResult Search(string origin, string destination, DateOnly? departure, DateOnly? returnDate)
        {
            var tickets = _ticketService.SearchTickets(origin, destination, departure, returnDate);
            return View("SearchResults", tickets);
        }

        // GET: Tickets/Details/5
        public IActionResult Details(int id)
        {
            var ticket = _ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FlightNumber,Airline,DepCity,DepAirport,ArrCity,ArrAirport,DepDate,ArrDate,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.CreateTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(int id)
        {
            var ticket = _ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TicketID,FlightNumber,Airline,DepCity,DepAirport,ArrCity,ArrAirport,DepDate,ArrDate,Price")] Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _ticketService.UpdateTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(int id)
        {
            var ticket = _ticketService.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket != null)
            {
                _ticketService.DeleteTicket(ticket);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}