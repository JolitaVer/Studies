using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Studies;


namespace Studies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManipulationWithData.DeleteDataOnTable<Student>();
            ManipulationWithData.DeleteDataOnTable<Lecture>();
            ManipulationWithData.DeleteDataOnTable<Departament>();

            ManipulationWithData.AddItem<Departament>("Departament");
            ManipulationWithData.AddItem<Lecture>("Lecture");
            ManipulationWithData.AddItem<Student>("Petraitis");


            ManipulationWithData.AddItem<Departament>(new List<string> { "Science", "Mathematics", "Enginering", "Arts", "Technologies" });
            ManipulationWithData.AddItem<Lecture>(new List<string> { "Biology", "Algebra", "Geometry", "Art", "Handicrafts", "Draughtsmanship", "Chemistry", "Construction", "Management" });
            ManipulationWithData.AddItem<Student>(new List<string> { "Jonaitis", "Stasiūnas", "Karalaitė", "Vanagaitė", "Beržinis", "Vasaraitė" });

            using (var context = new StudiesContext())
            {
                var addDepartament = new Departament()
                {
                    DepName = "Self Expression",
                    Lectures = new List<Lecture>()
                    {
                        new Lecture() { Title = "Acting"},
                        new Lecture() { Title = "Choreography"},
                        new Lecture() { Title = "Sculpture"},
                        context.Lectures.FirstOrDefault(l => l.Title == "Art")
                    },
                    Students = new List<Student>()
                    {
                        new Student() { Name = "Oželytė"},
                        new Student() { Name = "Malinauskas"},
                        new Student() { Name = "Gervelė"},
                        context.Students.FirstOrDefault(s => s.Name == "Vanagaitė")
                    }
                };

                var addLectureFromDB = context.Lectures.FirstOrDefault(l => l.Title == "Draughtsmanship");
                var addStudentFromDB = context.Students.FirstOrDefault(s => s.Name == "Stasiūnas");

                addDepartament.Lectures.Add(addLectureFromDB);
                addDepartament.Students.Add(addStudentFromDB);

                context.Departaments.Add(addDepartament);


                var updateDepartment = context.Departaments.FirstOrDefault(d => d.DepName == "Enginering");
                var addLecture = context.Lectures.FirstOrDefault(l => l.Title == "Construction");
                var addNewLecture = new Lecture() { Title = "Transport" };
                var addStudent = context.Students.FirstOrDefault(s => s.Name == "Vanagaitė");
                var addNewStudent = new Student() { Name = "Laukelis" };

                updateDepartment.Lectures.Add(addLecture);
                updateDepartment.Lectures.Add(addNewLecture);
                updateDepartment.Lectures.Add(new Lecture() { Title = "Mathematical analysis" });
                updateDepartment.Students.Add(addStudent);
                updateDepartment.Students.Add(addNewStudent);
                updateDepartment.Students.Add(new Student() { Name = "Klaidelė" });
                context.Departaments.Update(updateDepartment);

                context.SaveChanges();
            }
        }
    }
}

