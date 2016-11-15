namespace EventBoard.DataAccess.EntityFramework
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Claim: IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
