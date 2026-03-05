using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Users;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure
{
    public class UserRepository : IUsersRepository
    {
        private readonly EsportsCmsContext _dbContext;
        public UserRepository(EsportsCmsContext dbContext)
        {
            _dbContext = dbContext;
        }



        public Task<List<User>> GetAllStudentsAsync()
        {
            return _dbContext.Users.ToListAsync();
        }

        public async Task<bool> AssignStudentToCollegeAsync(Guid? userId, int? collegeId)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                return false;

            user.CollegeId = collegeId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveStudentFromCollegeAsync(Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                return false;

            user.CollegeId = null;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
