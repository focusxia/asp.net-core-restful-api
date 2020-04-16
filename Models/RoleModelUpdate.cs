using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Models
{
    public class RoleModelUpdate
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public List<Guid> Permissions { get; set; }
    }
}
