using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Events.BlogCreatedEvent
{
    public class SendEmailEventHandler : INotificationHandler<BlogCreatedEvent>
    {
        private readonly ILogger<SendEmailEventHandler> logger;

        public SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        {
            this.logger = logger;
        }

        public async Task Handle(BlogCreatedEvent notification, CancellationToken cancellationToken)
        {
            // send mail for user
            await Task.Delay(1000);

            logger.LogCritical($"send mail successfully!!! {notification.Id}");
        }
    }
}
