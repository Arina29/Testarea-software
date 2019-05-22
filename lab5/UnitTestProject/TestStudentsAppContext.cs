using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5.Models;

namespace UnitTestProject
{
    public class TestStudentsAppContext : IStudentsAppContext
    {
        public TestStudentsAppContext()
        {
            this.Students = new DbSetStudentsTest();
        }

        public DbSet<Student> Students { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Student item) { }
        public void Dispose() { }
    }
}
