namespace EventManagerPK.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
        public string Organizer { get; set; } = string.Empty;
        public EventCategory Category { get; set; }
        public bool IsFeatured { get; set; }
    }

    public enum EventCategory
    {
        Conference,
        Workshop,
        Concert,
        Exhibition,
        Sports,
        Networking,
        Other
    }
}
