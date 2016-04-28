using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class AppUser : IdentityUser
    {
        override public string UserName { get; set; }
        override public string Email { get; set; }
    }
}
