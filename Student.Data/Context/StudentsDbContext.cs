using Microsoft.EntityFrameworkCore;
using Student.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Data.Context
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options):base(options)
        {
            
        }

        public DbSet<StudentModel> students { get; set; }

    }
}
