using EventBoard.DataAccess.EntityFramework;
using EventBoard.Domain.Models;
using System.Collections.Generic;

namespace EventBoard.Domain
{
    public interface IEventService
    {
        AllEventsModel GetAllEvents();
        int CreateNewEvent(EventNewViewModel newEventInfo, string userName);
        EventFullModel GetEvent(int eventId);
        CategoryEventsViewModel GetEventsByCategory(int categoryId);
        void AddNewComment(string userName, CommentNewViewModel comment);
    }
}
