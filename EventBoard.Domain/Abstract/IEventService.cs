using EventBoard.DataAccess.EntityFramework;
using EventBoard.Domain.Models;

namespace EventBoard.Domain
{
    public interface IEventService
    {
        AllEventsModel GetAllEvents();
        int CreateNewEvent(EventNewViewModel newEventInfo, string userName);
        EventFullModel GetEvent(int eventId);
    }
}
