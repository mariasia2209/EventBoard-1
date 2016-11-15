namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Heading { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public int Event_Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Author_Id { get; set; }

        public DateTime Time { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
