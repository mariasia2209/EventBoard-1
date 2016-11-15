namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Recipient_Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Sender_Id { get; set; }

        public byte? Type { get; set; }

        public DateTime TimeSent { get; set; }

        [StringLength(200)]
        public string ObjectLink { get; set; }

        [StringLength(200)]
        public string Message { get; set; }

        public bool IsUnread { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
