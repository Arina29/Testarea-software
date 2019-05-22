using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models
{
    public interface IStudentsAppContext : IDisposable  
    {
        DbSet<Student> Students { get; }

        int SaveChanges();

        void MarkAsModified(Student item);
    }
}
