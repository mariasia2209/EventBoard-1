using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EventBoard.DataAccess.EntityFramework;

namespace EventBoard.Presentation.Tests.DatabaseHelpers
{
    public class TestContext : IEventBoardContext
    {
        public TestContext()
        {
            Categories = new TestDbSet<Category>();
            Claims = new TestDbSet<Claim>();
            Comments = new TestDbSet<Comment>();
            Events = new TestDbSet<Event>();
            EventSubscriptions = new TestDbSet<EventSubscription>();
            Groups = new TestDbSet<Group>();
            Likes = new TestDbSet<Like>();
            Logins = new TestDbSet<Login>();
            Messages = new TestDbSet<Message>();
            News = new TestDbSet<News>();
            Notifications = new TestDbSet<Notification>();
            Organizers = new TestDbSet<Organizer>();
            Reposts = new TestDbSet<Repost>();
            Roles = new TestDbSet<Role>();
            Streams = new TestDbSet<Stream>();
            Subscriptions = new TestDbSet<Subscription>();
            Tags = new TestDbSet<Tag>();
            UserRoles = new TestDbSet<UserRole>();
            Users = new TestDbSet<User>();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSubscription> EventSubscriptions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Repost> Reposts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            SaveChangesCount++;
            return 1;
        }

        public void Dispose() { }
    }
}
