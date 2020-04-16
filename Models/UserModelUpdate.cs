﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Models
{
    public class UserModelUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}
