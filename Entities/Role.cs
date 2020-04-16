using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Entities
{
    public class Role
    {
        public Role()
        {
            UserRoleRelationship = new List<UserRoleRelationship>();
            RolePermissionRelationship = new List<RolePermissionRelationship>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRoleRelationship> UserRoleRelationship { get; set; }
        public ICollection<RolePermissionRelationship> RolePermissionRelationship { get; set; }
    }
}
