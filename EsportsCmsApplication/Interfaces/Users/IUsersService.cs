using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.DTOs.EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Users
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAllStudentsAsync();
        Task<bool> AssignStudentToCollegeAsync(AssignUserToCollegeDto dto);
        Task<bool> RemoveStudentFromCollegeAsync(RemoveUserFromCollegeDto userId);

        Task<UserDto?> GetUserByIdAsync(Guid userId);
        Task<bool> JoinTeamAsync(JoinTeamDto dto);
        Task<bool> LeaveTeamAsync(LeaveTeamDto dto);


    }
}
