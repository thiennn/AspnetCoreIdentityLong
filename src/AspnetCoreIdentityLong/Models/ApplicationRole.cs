using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspnetCoreIdentityLong.Models
{
    public class ApplicationRole : IdentityRole<long, ApplicationUserRole, IdentityRoleClaim<long>>
    {
    }
}
