using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Roles;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure
{
    public class RoleRepository : IRoleRepository
    {

        private readonly EsportsCmsContext _dbContext;

        public RoleRepository(EsportsCmsContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public Task<List<RoleDto>> GetAllRolesAsync()
        {
            return _dbContext.Roles.ToListAsync().ContinueWith(task =>
            {
                return task.Result.Select(role => new RoleDto
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName
                }).ToList();
            });
        }
    }
}
