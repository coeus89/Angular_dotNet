﻿using StudentAdminPortal.API.DataModels;
using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;
        
        public SqlStudentRepository(StudentAdminContext context)
        {
            this._context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync<Student>();
        }
    }
}
