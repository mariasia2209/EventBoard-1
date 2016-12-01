﻿using EventBoard.DataAccess.EntityFramework;
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

                Image = e.Image,
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

        public EventFullModel GetEvent(int eventId)
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
    }
}
