using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.Models
{
    public class Cicle
    {
        public string Description { get; set; }
        public string FullName { get; set; }
        public List<string> Subjects { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
