using EventBoard.Domain.Models;

namespace EventBoard.Domain
{
    public interface IEventService
    {
        AllEventsModel GetAllEvents();
    }
}
