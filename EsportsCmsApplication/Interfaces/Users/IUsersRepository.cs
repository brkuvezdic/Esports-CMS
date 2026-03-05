using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Users
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllStudentsAsync();
        Task<bool> AssignStudentToCollegeAsync(Guid? userId, int? collegeId);
        Task<bool> RemoveStudentFromCollegeAsync(Guid userId);

    }
}
