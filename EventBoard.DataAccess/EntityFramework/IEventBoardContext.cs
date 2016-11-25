using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.DataAccess.EntityFramework
{
    public interface IEventBoardContext: IDisposable
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Claim> Claims { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventSubscription> EventSubscriptions { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Login> Logins { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<News> News { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Organizer> Organizers { get; set; }
        DbSet<Repost> Reposts { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Stream> Streams { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
