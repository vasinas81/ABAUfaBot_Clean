
using ABAUfaBot.Domain;
using System.Collections.Generic;

namespace ABAGoogleDocs.Models
{
    public class ABAUser : IABAUser
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public bool isAuthorized { get; set; }
        public UserRoles? Role { get; set; }
        public List<string> ChildNames { get; set; }
        public  string TableId { get; set; }

        public ABAUser()
        { }

    }
}
