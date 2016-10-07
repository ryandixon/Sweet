﻿using System.Linq;
using System.Web.Mvc;
using Sweet.Models;

namespace Sweet.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public TicketsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = _dbContext.Tickets.ToList();
            return View(tickets);
        }
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var ticket = _dbContext.Tickets.SingleOrDefault(v => v.Id == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        [HttpPost]
        public ActionResult Update(Ticket ticket)
        {
            var ticketInDb = _dbContext.Tickets.SingleOrDefault(v => v.Id == ticket.Id);
            if (ticketInDb == null)
                return HttpNotFound();

            ticketInDb.Title = ticket.Title;
            ticketInDb.Description = ticket.Description;
            ticketInDb.Urgency = ticket.Urgency;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var ticket = _dbContext.Tickets.SingleOrDefault(v => v.Id == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var ticket = _dbContext.Tickets.SingleOrDefault(v => v.Id == id);

            if (ticket == null)
                return HttpNotFound();

            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}