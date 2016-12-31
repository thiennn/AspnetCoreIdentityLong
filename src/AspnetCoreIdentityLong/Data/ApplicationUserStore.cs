using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspnetCoreIdentityLong.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspnetCoreIdentityLong.Data
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, long, IdentityUserClaim<long>, ApplicationUserRole,
        IdentityUserLogin<long>, IdentityUserToken<long>>
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {
        }

        protected override IdentityUserClaim<long> CreateUserClaim(ApplicationUser user, Claim claim)
        {
            var userClaim = new IdentityUserClaim<long> { UserId = user.Id };
            userClaim.InitializeFromClaim(claim);
            return userClaim;
        }

        protected override IdentityUserLogin<long> CreateUserLogin(ApplicationUser user, UserLoginInfo login)
        {
            return new IdentityUserLogin<long>
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override ApplicationUserRole CreateUserRole(ApplicationUser user, ApplicationRole role)
        {
            return new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
        }

        protected override IdentityUserToken<long> CreateUserToken(ApplicationUser user, string loginProvider, string name, string value)
        {
            return new IdentityUserToken<long>
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }
    }
}
