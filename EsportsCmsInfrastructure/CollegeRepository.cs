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

        public Task<List<College>> GetAllCollegesAsync()
        {
            return _dbContext.Colleges.ToListAsync();
        }

        public async Task<College?> GetCollegeByIdAsync(int id)
        {
            return await _dbContext.Colleges.FindAsync(id);
        }



        public async Task<bool> CollegeExistsAsync(string Title)
        {
            return await _dbContext.Colleges.AnyAsync(c => c.Title == Title);
        }



        public async Task<College> AddCollegeAsync(College college)
        {
            await _dbContext.Colleges.AddAsync(college);
            await _dbContext.SaveChangesAsync();
            return college;
        }

        public async Task<College> DeleteCollegeAsync(College college)
        {
            _dbContext.Colleges.Remove(college);
            await _dbContext.SaveChangesAsync();
            return college;
        }

        public async Task<College> UpdateCollegeAsync(College college)
        {
            _dbContext.Colleges.Update(college);
            await _dbContext.SaveChangesAsync();
            return college;
        }


        public async Task<College> UpdateCollegeDescriptionAsync(int collegeId, string description)
        {
            var college = await _dbContext.Colleges.FindAsync(collegeId);

            if (college == null)
                throw new KeyNotFoundException($"College with ID {collegeId} not found.");

            college.Description = description; 
            _dbContext.Colleges.Update(college);

            await _dbContext.SaveChangesAsync();

            return college;
        }











        public Task<List<College>> GetCollegesWithTeamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<College?> GetCollegeWithStudentsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<College?> GetCollegeWithTeamsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<College>> SearchCollegesByNameAsync(string Title)
        {
            throw new NotImplementedException();
        }

    }
}
