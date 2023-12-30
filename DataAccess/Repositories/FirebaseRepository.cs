using Firebase.Database;
using Firebase.Database.Query;
using M06_A01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.DataAccess.Repositories
{
    public class FirebaseRepository : IFirebaseRepository
    {
        public FirebaseClient Client;

        public FirebaseRepository()
        {
            Client = FirebaseConnection.GetFirebaseClient("https://testdam-87ae2-default-rtdb.europe-west1.firebasedatabase.app/", "RngqMM6D4TjFp3ZmCJXDlEpynTUmKK1Gk1OJLkfJ");
        }

        public async Task<bool> AddStudent(Student student)
        {
            bool result;
            try
            {
                var customStudent = new
                {
                    AverageScore = student.AverageScore,
                    BirthDate = student.BirthDate,
                    Cicle = student.Cicle,
                    Dual = student.Dual,
                    Email = student.Email,
                    Hobbies = student.Hobbies,
                    Id = student.Id
                };
                await Client
                .Child("Students")
                .Child(student.FullName)
                .PutAsync(customStudent);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> ExistsStudent(string name)
        {
            return await Client
                .Child("Students")
                .Child($"{name}")
                .OnceSingleAsync<Student>() != null;
        }

        public async Task<Student> GetStudent(string name)
        {
            return await Client
                .Child("Students")
                .Child($"{name}")
                .OnceSingleAsync<Student>();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents()
        {
            return await Client
                .Child("Students")
                .OnceAsync<Student>();
        }

        public async Task<bool> RemoveStudent(string name)
        {
            bool result;
            try
            {
                await Client
                    .Child("Students")
                    .Child($"{name}")
                    .DeleteAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            bool result;
            try
            {
                await Client
                    .Child("Students")
                    .Child($"{student.Id}")
                    .PutAsync(student);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
