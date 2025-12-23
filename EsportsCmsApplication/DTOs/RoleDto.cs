using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.DTOs
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}
