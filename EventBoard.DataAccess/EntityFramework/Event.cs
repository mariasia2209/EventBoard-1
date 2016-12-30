namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            Comments = new HashSet<Comment>();
            EventSubscriptions = new HashSet<EventSubscription>();
            Likes = new HashSet<Like>();
            News = new HashSet<News>();
            Reposts = new HashSet<Repost>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime EventBegin { get; set; }

        public DateTime EventEnd { get; set; }

        public string Location { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Description { get; set; }

        public bool Suspended { get; set; }

        [StringLength(10)]
        public string maximumAmount { get; set; }

        [StringLength(128)]
        public string Creator_Id { get; set; }

        [StringLength(128)]
        public string Stream_Id { get; set; }

        public int? Organizer_Id { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double Priority { get; set; }

        public int Category_Id { get; set; }

        [StringLength(30)]
        public string BackgroundColor { get; set; }

        [StringLength(30)]
        public string TitleColor { get; set; }

        [StringLength(10)]
        public string EventStatus { get; set; }

        [StringLength(64)]
        public string GoogleId { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Organizer Organizer { get; set; }

        public virtual Stream Stream { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventSubscription> EventSubscriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repost> Reposts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
