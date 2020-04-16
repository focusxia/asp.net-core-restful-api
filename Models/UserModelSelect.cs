using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Models
{
    public class UserModelSelect
    {
        public UserModelSelect()
        {
            Roles = new List<RoleModelSelect>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<RoleModelSelect> Roles { get; set; }
    }
}
