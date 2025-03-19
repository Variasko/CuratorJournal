using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public class App
    {
        public static void Main()
        {
            Student student1 = new Student(1, "James", new List<int> { 5, 4, 5 });
            Student student2 = new Student(1, "James1", new List<int> { 5, 3, 3 });

            Console.Write("До добавления к 1 студенту: ");
            foreach (int g in student1.Grades)
                Console.Write(g.ToString() + ' ');
            Console.WriteLine();
            student1.AddGrade(3);
            Console.Write("После добавления к 1 студенту: ");
            foreach (int g in student1.Grades)
                Console.Write(g.ToString() + ' ');
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            decimal avg1 = (decimal)student1.GetAverage();
            decimal avg2 = (decimal)student2.GetAverage();
            Console.WriteLine("Средний балл 1 студента: " + avg1.ToString() + "\nBторого: " + avg2.ToString());
        }
    }
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Grades { get; set; }

        public Student(int Id, string Name, List<int> Grades)
        {
            this.Id = Id;
            this.Name = Name;
            this.Grades = Grades;
        }

        public void AddGrade(int grade)
        {
            this.Grades.Add(grade);
        }
        public decimal GetAverage()
        {
            return Math.Round((decimal)this.Grades.Sum() / this.Grades.Count, 2);
        }
    }
}