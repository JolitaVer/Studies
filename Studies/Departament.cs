using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studies
{
    public class Departament
    {
        public int Id { get; set; }
        public string DepName { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
