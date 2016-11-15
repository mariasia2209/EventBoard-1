namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        [StringLength(128)]
        public string Author_Id { get; set; }

        [StringLength(128)]
        public string Recipient_Id { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
