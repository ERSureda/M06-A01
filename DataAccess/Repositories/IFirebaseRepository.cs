using Firebase.Database;
using M06_A01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.DataAccess.Repositories
{
    public interface IFirebaseRepository
    {
        public Task<bool> ExistsStudent(string name);
        public Task<bool> RemoveStudent(string name);
        public Task<bool> AddStudent(Student student);
        public Task<bool> UpdateStudent(Student student);
        public Task<Student> GetStudent(string name);
        public Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents();
    }
}
