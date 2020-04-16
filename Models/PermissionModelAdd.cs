using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Models
{
    public class PermissionModelAdd
    {
        public string Name { get; set; }
        public string Url { get; set; }
        //1.菜单 2.操作
        public int Type { get; set; }
        public Guid PId { get; set; }
    }
}
