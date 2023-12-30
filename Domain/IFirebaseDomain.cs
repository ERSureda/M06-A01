using M06_A01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.Domain
{
    public interface IFirebaseDomain
    {
        public Task<bool> ExistStudent(string name);
        public Task<bool> AddStudent(Student student);
        public Task<bool> RemoveStudent(string name);
        public Task<bool> RemoveStudent(Student studen);
        public Task<Student> GetStudent(string name);
        public Task<Student> GetStudent(Student studen);
        public Task<List<Student>> GetListStudents();
    }
}
