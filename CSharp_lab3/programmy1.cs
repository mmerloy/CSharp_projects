using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ConsoleApp2;

namespace ConsoleApp2
{
    class programmy1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("#1");
            Student student1 = new Student( new Person("Juk", "Jujashi", new DateTime(2000, 07, 09)),Education.Bachelor, 24);
            Exam[] exams = new Exam[2];
            exams[0] = new Exam("Russian", 3, new DateTime(2020, 05, 03));
            exams[1] = new Exam("Phisics", 5, new DateTime(2019, 01, 07));
            Test[] tests = new Test[2];
            tests[0] = new Test("Program", true);
            tests[1] = new Test("English", false);
            student1.AddExams(exams);
            student1.AddTest(tests);
            Console.WriteLine(student1.ToString());
            student1.SortBySubject();
            Console.WriteLine(student1.ToString());
            student1.SortByGrade();
            Console.WriteLine(student1.ToString());
            student1.SortByDate();
            Console.WriteLine(student1.ToString());
            Console.WriteLine("#2");


            StudentCollection<string> students = new StudentCollection<string>(e => e.Surname);
            students.AddDefaults();
            students.AddStudents(student1);
            Console.WriteLine(students.ToString());

            Console.WriteLine("#3");
            Console.WriteLine(students.GetMaxGrade());
            foreach (var stud in students.EducationForm(Education.Specialist))
            {
                Console.WriteLine(stud.Value);
            }

            Console.WriteLine("\n");
            foreach (var stud in students.GroupByEducation)
            {
                Console.Write(stud.Key + " ");
                foreach (var val in stud)
                {
                    Console.WriteLine(val.Value);
                }

            }

            Console.WriteLine("#4");
            int i = 0;
            bool get = true;
            while (get)
                try
                {
                    Console.WriteLine("Введите число: ");
                    i = int.Parse(Console.ReadLine());
                    get = false;
                }
                catch (Exception)
                { get = true;  }
            KeyValuePair<Person, Student> PairGen(int inp)
            {
                Student student2 = new Student( new Person("Test" + inp, "test" + inp / 2, new DateTime(2001 + inp % 3, 02, 02)),Education.Bachelor, 20);

                return new KeyValuePair<Person, Student>(student2.Person, student2);
            }

            TestCollections<Person, Student> test = new TestCollections<Person, Student>(PairGen, i);
            test.Search(PairGen(0));
            test.Search(PairGen(i / 2));
            test.Search(PairGen(i - 1));
            test.Search(PairGen(i));
            Console.Read();


        }
    }
}


