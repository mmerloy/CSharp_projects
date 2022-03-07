using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Linq;
using ConsoleApp2;
using System.Collections;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{ 
    class Student: Person, IDateAndCopy, IEnumerable
    {
        //закрытые поля
        private Education education_form;
        private int group_number;
        private ArrayList tests;
        private ArrayList exams;
        

        // определяем конструктор с параметрами
        public Student (Person student_inf1, Education education_form1, int group_number1):base(student_inf1.Name, student_inf1.Surname, student_inf1.Date)
        {
           // name = student_inf1.Name;
           // surname = student_inf1.Surname;
           // birthday = student_inf1.Date;
            education_form = education_form1;
            group_number = group_number1;
            exams = new ArrayList();
            tests = new ArrayList();
        } 

        //определяем конструктор без параметров
        //  :base() - штука которая позволяет убрать какие-то элементы
        public Student():base()
        {
            //Person inf = new Person();
            //name = inf.Name;
            //surname = inf.Surname;
            //birthday = inf.Date;
            education_form = Education.Specialist;
            group_number = 0;
            exams = new ArrayList();
            tests = new ArrayList();

        }

        //определяем  свойства c методами get и set:
        public Person Person
        {
            get
            { return new Person(name, surname, birthday); }
            set
            {
                name = value.Name;
                surname = value.Surname;
                birthday = value.Date;
            }
        }
        public Education form
        {
            get
            { return education_form;}
            set
            { education_form = value;}
        }
        public int Group
        {
            get
            {return group_number;}
            set
            {
                if (value <= 100 || value > 599)
                { throw new ArgumentException("Number of group must be > 100 and < 600");  }
            }
        }
        public ArrayList Exams
        {
            get
            { return exams;}
            set
            { exams = value;}
        }

        public ArrayList Tests
        {
            get
            { return tests;}
            set
            { tests = value;}
        }

        // свойство типа double
        public  double Grade //средний балл
        {
            get 
            {
                if (exams.Count != 0)
                {
                    double sum = 0;
                    for (int i = 0; i < exams.Count; i++)
                        sum += ((Exam)exams[i]).Mark;
                    return (sum / exams.Count);
                }
                else
                    return 0;

            }

        }

        public bool this[Education e]
        {
            get
            { return education_form == e; }
        }


        public IEnumerable ExamsAndTests()
        {
            for (int i = 0; i < exams.Count; i++)
            { yield return exams[i]; }

            for (int i = 0; i < tests.Count; i++)
            { yield return tests[i]; }
        }

        public IEnumerable FilteredExams(int oc)
        {
            for (int i = 0; i < exams.Count; i++)
            {
                if (((Exam)exams[i]).Mark > oc)
                { yield return exams[i]; }
            }
        }


        public IEnumerator GetEnumerator()
        { return new StudentEnumerator(tests, exams); }


        public IEnumerable PassedExamsAndTests()
        {
            for (int i = 0; i < exams.Count; i++)
            { if (((Exam)exams[i]).Mark > 2) yield return exams[i]; }

            for (int i = 0; i < tests.Count; i++)
            { if (((Test)tests[i]).result) yield return tests[i]; }
            
        }


        public IEnumerable PassedSubjects()
        {
            foreach (var test in tests)
            {
                foreach (var exam in exams)
                {
                    if (((Test)test).result && ((Test)test).Name == ((Exam)exam).Name && ((Exam)exam).Mark > 2)
                    {
                        yield return test;
                        break;
                    }
                }
            }
        }


        public void AddExams(params Exam[] adding_ex)
        {
            for (int i = 0; i < adding_ex.Length; i++)
                exams.Add(adding_ex[i]);
        }


        public void AddTests(params Test[] adding_ts)
        {
            for (int i = 0; i < adding_ts.Length; i++)
            { tests.Add(adding_ts[i]); }
        }


        public override string ToString()
        {
            string s ="\n"+ name.ToString() + " " + surname.ToString() + " " + birthday.ToString("d") + " " + education_form.ToString() + " " + group_number.ToString()+"\n";
            if (exams != null)
            {
                for (int i = 0; i < exams.Count; i++)
                { s += " | " + exams[i].ToString(); }
            }
            s += " | ";
            if (tests != null)
            {
                for (int i = 0; i < tests.Count; i++)
                { s += " | " + tests[i].ToString(); }
            }  
            return s;
        }


        public override string ToShortString()
        {
            return name.ToString() + " " + surname.ToString() + " " + birthday.ToString("d") + " " + education_form.ToString() + " " + group_number.ToString() + " " + Grade.ToString();
        }


        public override bool Equals(object obj)
        {
            if ((obj.GetType() != GetType()) || (obj == null)) return false;
            Student comp = (Student)obj;
            bool ans = (name == comp.name) && (surname == comp.surname) && (birthday == comp.birthday) && (education_form == comp.education_form) && (group_number == comp.group_number);
            if (tests.Count != comp.tests.Count || exams.Count != comp.exams.Count) return false;
            for (int i = 0; i < tests.Count; i++)
            {
                ans = ans && (((Test)tests[i]).Name == ((Test)comp.tests[i]).Name) && (((Test)tests[i]).result == ((Test)comp.tests[i]).result);
            }
            for (int i = 0; i < exams.Count; i++)
            {
                ans = ans && ((Exam)exams[i]).Equals((Exam)(((Student)comp).exams[i]));
            }
                return ans;
        }


        public static bool operator ==(Student a, Student b)
        { return a.Equals(b); }


        public static bool operator !=(Student a, Student b)
        { return !a.Equals(b); }


        public override int GetHashCode()
        {
            int ans = name.GetHashCode() ^ surname.GetHashCode() ^ birthday.GetHashCode() ^ education_form.GetHashCode() ^ group_number.GetHashCode();
            foreach (var test in tests)
            {
                ans = ans ^ ((Test)test).Name.GetHashCode() ^ ((Test)test).result.GetHashCode();
            }
            foreach (var exam in exams)
            {
                ans = ans ^ ((Exam)exam).GetHashCode();
            }
            return ans;
        }

        //перегруженная версия виртуального метода object DeepCopy();
        public override object DeepCopy()
        {
            Person per_copy = new Person(name, surname, birthday);
            Student s_copy = new Student(per_copy, education_form, group_number);
            for (int i = 0; i < exams.Count; i++)
            {
                s_copy.exams.Add(((Exam)exams[i]).DeepCopy());
            }
            ArrayList tests_copy = new ArrayList();
            for (int i = 0; i < tests.Count; i++)
            {
                s_copy.tests.Add(((Test)tests[i]).DeepCopy());
            }
            return s_copy;
        }


    }

   
}

