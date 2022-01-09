using System;
using System.Collections.Generic;

namespace ABAUfaBot.Domain
{
    public interface IABAUser
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public UserRoles? Role { get; set; }
        public bool isAuthorized { get; set; }
        public List<string> ChildNames { get; set; }
        public string TableId { get; set; }
    }
}
