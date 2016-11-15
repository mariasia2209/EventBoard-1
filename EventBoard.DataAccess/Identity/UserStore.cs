using EventBoard.DataAccess.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBoard.DataAccess.Identity
{
    public class UserStore: UserStore<User, Role, string, Login, UserRole, Claim>, IUserStore<User>
    {
        public UserStore(EventBoardContext context): base(context)
        {

        }
    }
}
