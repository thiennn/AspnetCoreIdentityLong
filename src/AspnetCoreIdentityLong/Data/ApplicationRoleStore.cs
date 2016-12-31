using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspnetCoreIdentityLong.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspnetCoreIdentityLong.Data
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, long, ApplicationUserRole, IdentityRoleClaim<long>>
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {
        }

        protected override IdentityRoleClaim<long> CreateRoleClaim(ApplicationRole role, Claim claim)
        {
            return new IdentityRoleClaim<long> { RoleId = role.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
        }
    }
}
