namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Like
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public int? LikedEvent_Id { get; set; }

        [StringLength(128)]
        public string Liker_Id { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
