using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class UserRoles : IdentityRole<Guid>
    {
        public UserRoles()
        {
            IsActive = true;
        }
        public bool IsActive { get; set; }
    }
}
