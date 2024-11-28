using Student.Business.Interfaces;
using Student.Data.Context;
using Student.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Repositories
{
    public class StudentRepositories : IStudentRepository
    {
        private readonly StudentsDbContext _dbContext;

        public StudentRepositories(StudentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(StudentModel student)
        {
            _dbContext.Add(student);
            return _dbContext.SaveChanges();
        }

        public int Delete(StudentModel student)
        {
            _dbContext.Remove(student);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return _dbContext.Set<StudentModel>().ToList();
        }

        public StudentModel GetByID(int id)
        {
            return _dbContext.Set<StudentModel>().Find(id);
        }

        public int Update(StudentModel student)
        {
            _dbContext.Update(student);
            return _dbContext.SaveChanges();
        }
    }
}
