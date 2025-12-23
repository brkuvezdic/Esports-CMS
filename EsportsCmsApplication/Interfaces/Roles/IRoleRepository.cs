using EsportsCmsApplication.DTOs;

namespace EsportsCmsApplication.Interfaces.Roles
{
    public interface IRoleRepository
    {
        Task<List<RoleDto>> GetAllRolesAsync();

    }
}
