using EventBoard.DataAccess.EntityFramework;
using EventBoard.Domain.Models;
using System.Collections.Generic;

namespace EventBoard.Domain
{
    public interface IEventService
    {
        AllEventsModel GetAllEvents();
        AllEventsModel EventsByUser(string UserId);
        int CreateNewEvent(EventNewViewModel newEventInfo, string userName);
        int UpdateEvent(EventNewViewModel newEventInfo, string userName, int eventId);
        EventFullModel GetEvent(int eventId, string userName);
        CategoryEventsViewModel GetEventsByCategory(int categoryId);
        void AddNewComment(string userName, CommentNewViewModel comment);
        void AddLike(int eventId, string userName);
        int get_events_num(string userId);
        int get_comments_num(string userId);
        int get_locked_comments_num(string userId);
        string get_user_name(string userId);
    }
}
