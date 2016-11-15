namespace EventBoard.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Repost
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public bool Suspended { get; set; }

        [StringLength(128)]
        public string Reposter_Id { get; set; }

        [StringLength(128)]
        public string Stream_Id { get; set; }

        public int? RepostedEvent_Id { get; set; }

        public virtual Event Event { get; set; }

        public virtual Stream Stream { get; set; }

        public virtual User User { get; set; }
    }
}
