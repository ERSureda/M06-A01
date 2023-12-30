using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace M06_A01.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public double AverageScore { get; set; }
        public DateTime BirthDate { get; set; }
        public Cicle Cicle { get; set; }
        public string Email { get; set; }
        public List<string> Hobbies { get; set; }
        public bool Dual { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
