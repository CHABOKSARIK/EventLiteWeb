using EventLiteWeb.Data;
using EventLiteWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EventLiteWeb.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            if (string.IsNullOrWhiteSpace(newEvent.Name))
            {
                throw new ArgumentException("Название мероприятия обязательно");
            }

            if (newEvent.Date < DateTime.Today)
            {
                throw new ArgumentException("Дата не может быть в прошлом");
            }

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent;
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToRemove = await _context.Events.FindAsync(id);

            if (eventToRemove != null)
            {
                _context.Events.Remove(eventToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}