namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventBoardContext : DbContext, IEventBoardContext
    {
        public EventBoardContext()
            : base("name=EventBoard")
        {
        }

        public static EventBoardContext Create()
        {
            return new EventBoardContext();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventSubscription> EventSubscriptions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<Repost> Reposts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Stream> Streams { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.Event_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventSubscriptions)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.Event_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.Event)
                .HasForeignKey(e => e.LikedEvent_Id);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.Event_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Reposts)
                .WithOptional(e => e.Event)
                .HasForeignKey(e => e.RepostedEvent_Id);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Events)
                .Map(m => m.ToTable("EventTags"));

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Streams)
                .WithOptional(e => e.Group)
                .HasForeignKey(e => e.Group_Id);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Groups1)
                .Map(m => m.ToTable("UserGroups"));

            modelBuilder.Entity<Organizer>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.Organizer)
                .HasForeignKey(e => e.Organizer_Id);

            modelBuilder.Entity<Stream>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.Stream)
                .HasForeignKey(e => e.Stream_Id);

            modelBuilder.Entity<Stream>()
                .HasMany(e => e.Reposts)
                .WithOptional(e => e.Stream)
                .HasForeignKey(e => e.Stream_Id);

            modelBuilder.Entity<Stream>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Stream)
                .HasForeignKey(e => e.Stream_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Claims)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Creator_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Creator_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EventSubscriptions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Subscriber_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Creator_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Liker_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Logins)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Author_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.Recipient_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.News)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Author_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Recipient_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.Sender_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reposts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Reposter_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Streams)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Users_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
