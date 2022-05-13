using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studies
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Departament> Departaments { get; set; } = new List<Departament>();
    }
}
