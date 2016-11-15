namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string Text { get; set; }

        public bool Suspended { get; set; }

        [Required]
        [StringLength(128)]
        public string Creator_Id { get; set; }

        public int Event_Id { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
