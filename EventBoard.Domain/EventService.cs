using EventBoard.DataAccess.EntityFramework;
using EventBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventBoard.Domain
{
    public class EventService : IEventService
    {
        private IEventBoardContext Context { get; set; }
        public EventService(IEventBoardContext context)
        {
            Context = context;
        }

        public AllEventsModel GetAllEvents()
        {
            List<EventShortModel> events = Context.Events.Select(e => new EventShortModel
            {
                Id = e.Id,
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
                Image = e.Image,

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
                    Users = e.Likes.Select(l => new UserShortModel
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
            })
            .OrderBy(e => e.Id)
            .ToList();

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

        public int CreateNewEvent(EventNewViewModel newEventInfo, string username)
        {
            int? categoryId = Context.Categories
                .Where(c => c.Name == newEventInfo.Category)
                .Select(c => c.Id)
                .FirstOrDefault();

            if (categoryId == 0)
            {
                Category newCategory = new Category
                {
                    Name = newEventInfo.Category
                };
                Context.Categories.Add(newCategory);
                Context.SaveChanges();
                categoryId = newCategory.Id;
            }

            Event newEvent = new Event
            {
                CreationTime = DateTime.Now,
                EventBegin = newEventInfo.StartTime,
                EventEnd = newEventInfo.EndTime,
                Location = newEventInfo.Location,

                Description = newEventInfo.Description,
                Name = newEventInfo.Name,
                Category_Id = categoryId.Value
            };

            Context.Events.Add(newEvent);
            
            Context.SaveChanges();

            return newEvent.Id;
        }

        public int UpdateEvent(EventNewViewModel newEventInfo, string username, int eventId)
        {
            int? categoryId = Context.Categories
                .Where(c => c.Name == newEventInfo.Category)
                .Select(c => c.Id)
                .FirstOrDefault();

            if (categoryId == 0)
            {
                Category newCategory = new Category
                {
                    Name = newEventInfo.Category
                };
                Context.Categories.Add(newCategory);
                Context.SaveChanges();
                categoryId = newCategory.Id;
            }
            
            var newEvent = Context.Events.Single(events => events.Id == eventId);
            newEvent.CreationTime = DateTime.Now;
            newEvent.EventBegin = newEventInfo.StartTime;
            newEvent.EventEnd = newEventInfo.EndTime;
            newEvent.Location = newEventInfo.Location;
            newEvent.Description = newEventInfo.Description;
            newEvent.Name = newEventInfo.Name;
            newEvent.Category_Id = categoryId.Value;

            Context.SaveChanges();

            return newEvent.Id;
        }

        public EventFullModel GetEvent(int eventId, string userName)
        {
            EventFullModel eventModel = Context.Events
                .Where(e => e.Id == eventId)
                .Select(e => new EventFullModel
                {
                    Id = e.Id,
                    Creator = new CreatorModel
                    {
                        Id = e.User.Id,
                        FirstName = e.User.FirstName,
                        SecondName = e.User.SecondName,
                        Sex = e.User.Sex,
                        Image = e.User.Image
                    },
                    CreationTime = e.CreationTime,
                    StartDate = e.EventBegin,
                    EndDate = e.EventEnd,
                    CategoryId = e.Category.Id,
                    CategoryName = e.Category.Name,
                    Name = e.Name,
                    Image = e.Image,
                    Description = e.Description,
                    Likes = new EventLikeCounterModel
                    {
                        Count = e.Likes.Count,
                        Users = e.Likes.Select(l => new UserShortModel
                        {
                            Id = l.User.Id,
                            FirstName = l.User.FirstName,
                            SecondName = l.User.SecondName,
                            Image = l.User.Image
                        }).ToList()
                    },
                    IsLikedByCurrentUser = userName == null ? false : e.Likes.Any(l => l.User.UserName == userName),
                    Tags = e.Tags.Select(t => new TagModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList(),
                    Comments = e.Comments.Select(c => new EventCommentModel
                    {
                        Id = c.Id,
                        Time = c.Time,
                        Text = c.Text,
                        User = new UserShortModel
                        {
                            Id = c.User.Id,
                            FirstName = c.User.FirstName,
                            SecondName = c.User.SecondName,
                            Image = c.User.Image
                        }
                    }).ToList()
                }).FirstOrDefault();

            return eventModel;
        }

        public CategoryEventsViewModel GetEventsByCategory(int categoryId)
        {
            CategoryEventsViewModel categoryModel = Context.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new CategoryEventsViewModel
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    Events = c.Events.Select(e => new EventHeaderModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        AuthorId = e.User.Id,
                        AuthorName = e.User.FirstName,
                        AuthorSurname = e.User.SecondName
                    }).ToList()
                }).FirstOrDefault();

            return categoryModel;
        }

        public void AddNewComment(string userName, CommentNewViewModel comment)
        {
            string userId = Context.Users
                .Where(u => u.UserName == userName)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null || comment.EventId == null)
            {
                return;
            }

            Comment newComment = new Comment
            {
                Time = DateTime.Now,
                Text = comment.Text,
                Suspended = false,
                Creator_Id = userId,
                Event_Id = (int)comment.EventId
            };

            Context.Comments.Add(newComment);

            Context.SaveChanges();

        }

        public void AddLike(int eventId, string userName)
        {
            if (userName == null)
            {
                return;
            }

            string userId = Context.Users
                .Where(u => u.UserName == userName)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return;
            }

            List<Like> existingLikes = Context.Likes.Where(l => l.Liker_Id == userId && l.LikedEvent_Id == eventId).ToList();

            if (existingLikes.Count == 0)
            {
                Like newLike = new Like
                {
                    LikedEvent_Id = eventId,
                    Liker_Id = userId,
                    Time = DateTime.Now
                };

                Context.Likes.Add(newLike);
            }
            else
            {
                Context.Likes.RemoveRange(existingLikes);
            }
            
            Context.SaveChanges();
        }
    }
}
