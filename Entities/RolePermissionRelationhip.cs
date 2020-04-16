using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Entities
{
    public class RolePermissionRelationship
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
