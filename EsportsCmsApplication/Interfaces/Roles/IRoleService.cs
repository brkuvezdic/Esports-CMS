using EsportsCmsApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Roles
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRolesAsync();

    }
}
