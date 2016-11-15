namespace EventBoard.DataAccess.EntityFramework
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Login: IdentityUserLogin<string>
    {
        public int Id { get; set; }

        public virtual User User { get; set; }
    }
}
