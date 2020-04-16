using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Models
{
    public class RoleModelAdd
    {
        public string Name { get; set; }

        public List<Guid> Permissions { get; set; }
    }
}
