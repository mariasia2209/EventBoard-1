namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscription
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(128)]
        public string Users_Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Stream_Id { get; set; }

        public bool Suspended { get; set; }

        public virtual Stream Stream { get; set; }

        public virtual User User { get; set; }
    }
}
