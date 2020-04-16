using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Entities
{
    public class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        //1.菜单 2.操作
        public int Type { get; set; }
        public Guid PId { get; set; }

        public ICollection<RolePermissionRelationship> RolePermissionRelationship { get; set; }
    }
}
