using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly EsportsCmsContext _dbContext;

        public CollegeRepository(EsportsCmsContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public  Task<List<College>> GetAllCollegesAsync()
        {
            return  _dbContext.Colleges.ToListAsync();
        }
    }
}
