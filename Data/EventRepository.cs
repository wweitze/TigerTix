﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public class EventRepository : IEventRepository
    {
        // inject tigertix context and create field to enable access
        private readonly TigerTixContext _context;
        public EventRepository(TigerTixContext context)
        {
            _context = context;
        }

        // methods to create, read, update, and delete data in Events table
        // save a event
        public void SaveEvent(Event ev)
        {
            _context.Add(ev);
            _context.SaveChanges();
        }

        //  returns all events
        public IEnumerable<Event> GetAllEvents()
        {
            var events = from u in _context.Events select u;

            return events.ToList();
        }

        // return a single event by ID
        public Event GetEventbyTitle(int eventId)
        {
            var target = (from u in _context.Events where u.Id == eventId select u).FirstOrDefault();

            return target;
        }

        public IEnumerable<Event> GetEventsByCoordinator(int userId)
        {
            var list = (from u in _context.Events where u.coordId == userId select u);

            return list;

        }

        // Update a event
        public void UpdateEvent(Event ev)
        {
            _context.Update(ev);
            _context.SaveChanges();
        }

        // Delete a user
        public void DeleteEvent(Event ev)
        {
            _context.Remove(ev);
            _context.SaveChanges();
        }

        // Save All
        public bool SaveAll()
        {
            // Save changes returns the row of numbers affected
            return _context.SaveChanges() > 0;
        }
    }
}