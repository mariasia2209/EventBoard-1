using EventBoard.DataAccess.EntityFramework;
using EventBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.Domain
{
    public class EventService: IEventService
    {
        private IEventBoardContext Context { get; set; }
        public EventService(IEventBoardContext context)
        {
            Context = context;
        }

        public AllEventsModel GetAllEvents()
        {
            List<StrictEventModel> events = Context.Events.Select(e => new StrictEventModel
            {
                Creator = new CreatorModel
                {
                    Id = e.User.Id,
                    FirstName = e.User.FirstName,
                    SecondName = e.User.SecondName,
                    Sex = e.User.Sex,
                    Image = e.User.Image
                },

                StartDate = e.EventBegin,
                EndDate = e.EventEnd,

                Category = e.Category.Name,

                Name = e.Name,
                Description = e.Description,

                Comments = new EventCommentsSummaryModel
                {
                    Count = e.Comments.Count(),
                    LastCommentDate = e.Comments.Max(c => c.Time)
                },

                Likes = new EventLikeCounterModel
                {
                    Count = e.Likes.Count(),
                    Users = e.Likes.Select(l => new UserLikeModel
                    {
                        Id = l.User.Id,
                        FirstName = l.User.FirstName,
                        SecondName = l.User.SecondName,
                        Image = l.User.Image
                    }).ToList()
                },

                Tags = e.Tags.Select(t => new TagModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList()
            }).ToList();

            EventsSummaryModel summary = new EventsSummaryModel
            {
                TotalEventCount = events.Count,
                TotalTagCount = Context.Tags.Count(),
                TotalCategoryCount = Context.Categories.Count(),
                TotalNewsCount = Context.News.Count()
            };

            List<CategoryModel> categories = Context.Categories.Select(c => new CategoryModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            List<TagModel> tags = Context.Tags.Select(t => new TagModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

            return new AllEventsModel
            {
                Events = events,
                Statistics = summary,
                Categories = categories,
                Tags = tags
            };
        }
    }
}
