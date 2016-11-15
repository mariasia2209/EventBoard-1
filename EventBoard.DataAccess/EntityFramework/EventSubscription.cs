namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventSubscription
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public int Event_Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Subscriber_Id { get; set; }

        public bool Suspended { get; set; }

        public int Type { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
