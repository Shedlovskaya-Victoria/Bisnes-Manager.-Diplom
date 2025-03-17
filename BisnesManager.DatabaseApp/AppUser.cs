using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Database
{
    public class AppUser : IdentityUser
    {
        public int RiskProperty {  get; set; }
    }
}
