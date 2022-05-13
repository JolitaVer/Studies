using Microsoft.EntityFrameworkCore;
using Studies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studies
{
    public class ManipulationWithData
    {
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public static void AddItem<T>(string item)
        {
            using (var context = new StudiesContext())
            {
                switch (typeof(T).Name)
                {
                    case "Departament":
                        if (!CheckIfExist<Departament>(item))
                        {
                            context.Departaments.Add(new Departament() { DepName = item });
                        }
                        break;
                    case "Lecture":
                        if (!CheckIfExist<Lecture>(item))
                        {
                            context.Lectures.Add(new Lecture() { Title = item });
                        }
                        break;
                    case "Student":
                        if (!CheckIfExist<Student>(item))
                        {
                            context.Students.Add(new Student() { Name = item });
                        }
                        break;
                }
                context.SaveChanges();
            }
        }
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void AddItem<T>(List<string> items)
        {
            foreach (string item in items)
            {
                AddItem<T>(item);
            }
        }
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public static bool CheckIfExist<T>(string item)
        {
            using (var context = new StudiesContext())
            {
                switch (typeof(T).Name)
                {
                    case "Departament":
                        if (context.Departaments.Where(d => d.DepName == item).Count() > 0)
                        {
                            return true;
                        }
                        break;
                    case "Lecture":
                        if (context.Lectures.Where(l => l.Title == item).Count() > 0)
                        {
                            return true;
                        }
                        break;
                    case "Student":
                        if (context.Students.Where(s => s.Name == item).Count() > 0)
                        {
                            return true;
                        }
                        break;
                }
            }
            return false;
        }
        public static void DeleteDataOnTable<T>()
        {
            using (var context = new StudiesContext())
            {
                switch (typeof(T).Name)
                {
                    case "Departament":
                        var deleteDepartament = context.Departaments;
                        foreach (var departament in deleteDepartament)
                        {
                            context.Departaments.Remove(departament);
                        }
                        break;
                    case "Lecture":
                        var deleteLecture = context.Lectures;
                        foreach (var lecture in deleteLecture)
                        {
                            context.Lectures.Remove(lecture);
                        }
                        break;
                    case "Student":
                        var deleteStudent = context.Students;
                        foreach (var student in deleteStudent)
                        {
                            context.Students.Remove(student);
                        }
                        break;
                }
                context.SaveChanges();
            }
        }        
    }
}