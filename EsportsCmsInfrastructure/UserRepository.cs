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
    }
}
