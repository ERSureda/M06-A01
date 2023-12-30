using M06_A01.DataAccess.Repositories;
using M06_A01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace M06_A01.Domain
{
    public class FirebaseDomain : IFirebaseDomain
    {
        public FirebaseFactory firebaseFactory;
        public IFirebaseRepository firebaseRepository;

        public FirebaseDomain()
        {
            firebaseFactory = new FirebaseFactory();
            firebaseRepository = firebaseFactory.GetFirebaseRepository();
        }

        public async Task<bool> AddStudent(Student student)
        {
            return await firebaseRepository.AddStudent(student);
        }

        public async Task<bool> ExistStudent(string name)
        {
            return await firebaseRepository.ExistsStudent(name);
        }

        public async Task<List<Student>> GetListStudents()
        {
            List<Student> list = (await firebaseRepository.GetStudents())
                .Select(firebaseObject => firebaseObject.Object)
                .ToList();
            return list;
        }

        public async Task<Student> GetStudent(string name)
        {
            return await firebaseRepository.GetStudent(name);
        }

        public async Task<Student> GetStudent(Student studen)
        {
            return await firebaseRepository.GetStudent(studen.FullName);
        }

        public async Task<bool> RemoveStudent(string name)
        {
            return await firebaseRepository.RemoveStudent(name);
        }

        public async Task<bool> RemoveStudent(Student studen)
        {
            return await firebaseRepository.RemoveStudent(studen.FullName);
        }
    }
}
