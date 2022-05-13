using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studies
{
    public class StudiesContext :DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBilder)
        {
            optionsBilder.UseSqlServer($"Server=localhost;Database=StudiesDb;Trusted_Connection=True;");
        }
    }
}

