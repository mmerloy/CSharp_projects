using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp2
{
    class programmy1
    {
        static void Main(string[] args)
        {
            Student per = new Student(new Person("Kremlin", "Kremlinov", new DateTime(2000, 4, 6)), Education.Bachelor, 24);
            Exam[] a_e = { new Exam("Math", 3, new DateTime(2020, 12, 12)), new Exam("Physics", 2, new DateTime(2020, 12, 12)), new Exam(), new Exam("English", 3, new DateTime(2020, 12, 12)), new Exam("Russian", 5, new DateTime(2020, 12, 12)) };
            Test[] a_t = { new Test("Physics", true), new Test("Math", true), new Test("test3", false), new Test("Russian", true) };
            per.AddExams(a_e);
            per.AddTests(a_t);
            Console.WriteLine(per.ToString() + "\n");
            Console.WriteLine(per.Person.ToString());
            Student stud_copy = (Student)per.DeepCopy();
            Console.WriteLine(ReferenceEquals(per, stud_copy));
            Console.WriteLine(Equals(per, stud_copy));
            Console.WriteLine(per.GetHashCode());
            Console.WriteLine(stud_copy.GetHashCode());
            per.Name = "Georg";
            ((Exam)per.Exams[0]).Mark = 8;
            Console.WriteLine(per.ToString());
            Console.WriteLine(stud_copy.ToString());

            try
            {
                per.Group = 601;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("------------------------------");


            foreach (var per_ex_t in per.ExamsAndTests())
            {
                Console.WriteLine(per_ex_t.ToString());
            }
            Console.WriteLine("------------------------------");


            foreach (var per_ex_f in per.FilteredExams(3))
            {
                Console.WriteLine(per_ex_f.ToString());
            }
            Console.WriteLine("------------------------------");


            foreach (var exam_and_test in per)
            {
                Console.WriteLine(exam_and_test);
            }
            Console.WriteLine("------------------------------");


            foreach (var per_passed_ex_t in per.PassedExamsAndTests())
            {
                Console.WriteLine(per_passed_ex_t.ToString());
            }
            Console.WriteLine("------------------------------");


            foreach (var per_passed_subj in per.PassedSubjects())
            {
                Console.WriteLine(per_passed_subj.ToString());
            }


        }
    }
}


