using MediatR;

namespace Application.Events.BlogCreatedEvent
{
    public class BlogCreatedEvent : INotification
    {
        public int Id { get; set; }
    }
}
