using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Events.webui.Identity
{
    public class User: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        
        
    }
}