using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CaseStudy
{
    public class EnrollExample
    {
        private StudentDB student { get; set; }
        private Courses course { get; set; }
        private DateTime enrollmentDate { get; set; }
        internal EnrollExample(StudentDB student, Courses course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }
    }
    class InfoE
    {
        public static void display(EnrollExample enroll)
        {
            Console.WriteLine(enroll);
        }
    }
    interface AppEngine
    {
        public void introduce(Courses course);
        public void register(StudentDB student);
        public List<StudentDB> ListOfStudent();
        public void enroll(StudentDB student, Courses course);
        public List<EnrollExample> ListOfEnrollments();
    }
    class InMemoryAppEngine : AppEngine
    {
        public void introduce(Courses course)
        {
            InfoC.display(course);
            //Console.WriteLine(course.ID + " " + course.Name + " " + course.Duration + " " + course.Fees);
        }
        public void register(StudentDB student)
        {
            Info.display(student);
            //Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));
        }
        public List<StudentDB> ListOfStudent()
        {
            int n;
            Console.WriteLine("Enter number of students: ");
            n = Convert.ToInt32(Console.ReadLine());
            List<StudentDB> studata = new List<StudentDB>();
            for (int i = 0; i < n; i++)
            {
                int StuID;
                string StuName;
                DateTime DOB;

                Console.WriteLine("Enter student id, name, dob");
                StuID = Convert.ToInt32(Console.ReadLine());
                StuName = Console.ReadLine();
                DOB = Convert.ToDateTime(Console.ReadLine());

                studata.Add(new StudentDB(StuID, StuName, DOB));
            }
            return studata;
        }

        public void enroll(StudentDB student, Courses course)
        {
            Console.WriteLine(course.ID + " " + course.Name + " " + course.Duration + " " + course.Fees);
            Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));
        }

        public List<EnrollExample> ListOfEnrollments()
        {
            StudentDB student = new StudentDB(1, "Ashwin", Convert.ToDateTime("14/01/1999"));
            StudentDB student1 = new StudentDB(2, "Ani", Convert.ToDateTime("19/05/1999"));
            StudentDB student2 = new StudentDB(3, "abu", Convert.ToDateTime("15/06/1999"));
            Courses course = new Courses(1001, "Java", "6 Months", 5000);
            Courses course1 = new Courses(1002, "Python", "6 Months", 7000);
            Courses course2 = new Courses(1003, "C#", "3 Months", 4000);

            Console.WriteLine("Enter the enrollment date");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            List<EnrollExample> enrollstudent = new List<EnrollExample>();

            EnrollExample enrollstudent1 = new EnrollExample(student, course, date);
            EnrollExample enrollstudent2 = new EnrollExample(student1, course1, date);
            EnrollExample enrollstudent3 = new EnrollExample(student2, course2, date);

            enrollstudent.Add(enrollstudent1);
            enrollstudent.Add(enrollstudent2);
            enrollstudent.Add(enrollstudent3);
            return enrollstudent;
        }
    }
    public class Enroll
    {
        static void Main()
        {
            AppEngine appengine = new InMemoryAppEngine();
            appengine.introduce(new Courses(1001, "Java", "1Year", 5000));
            Console.WriteLine("-----------------------------------------");

            appengine.register(new StudentDB(101, "Ashwin", Convert.ToDateTime("14/01/1999")));
            Console.WriteLine("-----------------------------------------");

            foreach (var s in appengine.ListOfStudent())
            {
                Console.WriteLine("Student ID: {0} || Student Name: {1} || Student DOB: {2}", s.id, s.name, s.dateofbirth);
            }
            Console.WriteLine("-----------------------------------------");
            appengine.enroll(new StudentDB(101, "Ashwin", Convert.ToDateTime("14/01/1999")), new Courses(1002, "Python", "6Months", 3000));
            Console.WriteLine("-----------------------------------------");

            foreach (var e in appengine.ListOfEnrollments())
            {
                InfoE.display(e);
            }
        }
    }
}