using Student.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAll();
        StudentModel GetByID(int id);
        int Add(StudentModel student);
        int Update(StudentModel student);
        int Delete(StudentModel student);
    }
}
