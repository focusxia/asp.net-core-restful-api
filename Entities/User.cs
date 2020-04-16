using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Entities
{
    public class User
    {
        public User()
        {
            UserRoleRelationship = new List<UserRoleRelationship>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<UserRoleRelationship> UserRoleRelationship { get; set; }
    }
}
