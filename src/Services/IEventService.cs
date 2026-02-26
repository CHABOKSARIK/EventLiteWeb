using EventLiteWeb.Models;

namespace EventLiteWeb.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> CreateEventAsync(Event newEvent);
        Task DeleteEventAsync(int id);
    }
}