using EventManagerPK.Models;
using EventManagerPK.Pages;

namespace EventManagerPK.Services;
public interface IEventService
{
    Task<Event> GetEventByIdAsync(int eventId);
    Task<List<Event>> GetFeaturedEventsAsync();
    Task<List<Event>> GetAllEventsAsync();
    Task UpdateEventAsync(Event eventToUpdate);
    Task AddAttendeeAsync(Attendee attendee);
    Task<List<Attendee>> GetAttendeesByEventIdAsync(int eventId);
}

public class EventService : IEventService
{
    private readonly List<Event> events;
    private List<Attendee> _attendees;

    public EventService()
    {
        // Initialize with some sample data
        events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Title = "Tech Conference 2024",
                Description = "Join us for the biggest tech conference of the year featuring speakers from around the world.",
                Date = DateTime.Now.AddDays(30),
                Location = "New York",
                ImageUrl = "images/events/tech-conference.png",
                Price = 299.99m,
                AvailableTickets = 50,
                Organizer = "Tech Events Inc.",
                Category = EventCategory.Conference,
                IsFeatured = true
            },
            new Event
            {
                Id = 2,
                Title = "Jazz Night",
                Description = "A night of smooth jazz and fine dining in the heart of the city.",
                Date = DateTime.Now.AddDays(14),
                Location = "Chicago",
                ImageUrl = "images/events/jazz-night.png",
                Price = 75.00m,
                AvailableTickets = 20,
                Organizer = "City Music Hall",
                Category = EventCategory.Concert,
                IsFeatured = false
            },
            new Event
            {
                Id = 3,
                Title = "Web Development Workshop",
                Description = "Learn modern web development techniques in this hands-on workshop.",
                Date = DateTime.Now.AddDays(7),
                Location = "Virtual",
                ImageUrl = "images/events/web-workshop.png",
                Price = 0m,
                AvailableTickets = 100,
                Organizer = "Code Academy",
                Category = EventCategory.Workshop,
                IsFeatured = true
            },
            new Event
            {
                Id = 4,
                Title = "Local Business Networking",
                Description = "Connect with local business owners and entrepreneurs.",
                Date = DateTime.Now.AddDays(3),
                Location = "Boston",
                ImageUrl = "images/events/networking.png",
                Price = 15.00m,
                AvailableTickets = 75,
                Organizer = "Chamber of Commerce",
                Category = EventCategory.Networking,
                IsFeatured = false
            },
            new Event
            {
                Id = 5,
                Title = "Art Exhibition",
                Description = "Explore the latest art pieces from local artists.",
                Date = DateTime.Now.AddDays(10),
                Location = "San Francisco",
                ImageUrl = "images/events/art-exhibition.png",
                Price = 20.00m,
                AvailableTickets = 100,
                Organizer = "Art Gallery",
                Category = EventCategory.Exhibition,
                IsFeatured = true
            },
            new Event
            {
                Id = 6,
                Title = "Startup Pitch Night",
                Description = "Watch startups pitch their ideas to investors.",
                Date = DateTime.Now.AddDays(5),
                Location = "Los Angeles",
                ImageUrl = "images/events/startup-pitch.png",
                Price = 50.00m,
                AvailableTickets = 30,
                Organizer = "Startup Hub",
                Category = EventCategory.Networking,
                IsFeatured = false
            },
            new Event
            {
                Id = 7,
                Title = "Marathon 2024",
                Description = "Join the annual marathon and run for a cause.",
                Date = DateTime.Now.AddDays(20),
                Location = "Boston",
                ImageUrl = "images/events/marathon.png",
                Price = 100.00m,
                AvailableTickets = 200,
                Organizer = "Sports Club",
                Category = EventCategory.Sports,
                IsFeatured = true
            },
            new Event
            {
                Id = 8,
                Title = "Cooking Workshop",
                Description = "Learn to cook gourmet meals with a professional chef.",
                Date = DateTime.Now.AddDays(12),
                Location = "New York",
                ImageUrl = "images/events/cooking-workshop.png",
                Price = 150.00m,
                AvailableTickets = 25,
                Organizer = "Culinary School",
                Category = EventCategory.Workshop,
                IsFeatured = false
            }
        };
        _attendees = new List<Attendee>();
    }

    public Task<Event> GetEventByIdAsync(int eventId)
    {
        return Task.FromResult(events.FirstOrDefault(e => e.Id == eventId));
    }
    public Task<List<Event>> GetFeaturedEventsAsync()
    {
        var featuredEvents = events.Where(e => e.IsFeatured).ToList();
        return Task.FromResult(featuredEvents);
    }
    public Task<List<Event>> GetAllEventsAsync()
    {
        return Task.FromResult(events);
    }
    public Task UpdateEventAsync(Event eventToUpdate)
    {
        var existingEvent = events.FirstOrDefault(e => e.Id == eventToUpdate.Id);
        if (existingEvent != null)
        {
            existingEvent.Title = eventToUpdate.Title;
            existingEvent.AvailableTickets = eventToUpdate.AvailableTickets;
            // Zaktualizuj inne w³aœciwoœci wed³ug potrzeb
        }
        return Task.CompletedTask;
    }
    public Task AddAttendeeAsync(Attendee attendee)
    {
        _attendees.Add(attendee);
        return Task.CompletedTask;
    }

    public Task<List<Attendee>> GetAttendeesByEventIdAsync(int eventId)
    {
        var attendees = _attendees.Where(a => a.EventId == eventId).ToList();
        return Task.FromResult(attendees);
    }
}