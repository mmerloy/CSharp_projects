using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleApp2;
using System.Collections;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ConsoleApplication2;

namespace ConsoleApp2
{
    delegate TKey KeySelector<TKey>(Student st);
    class Student: Person, IDateAndCopy, IEnumerable
    {
        //закрытые поля
        private Education education_form;
        private int group_number;
        private List<Test> allTest;
        private List<Exam> passedExams;


        // определяем конструктор с параметрами
        public Student (Person student_inf1, Education education_form1, int group_number1):base(student_inf1.Name, student_inf1.Surname, student_inf1.Date)
        {
           // name = student_inf1.Name;
           // surname = student_inf1.Surname;
           // birthday = student_inf1.Date;
            education_form = education_form1;
            group_number = group_number1;
            AllTest = new List<Test>();
            PassedExams = new List<Exam>();
        } 

        //определяем конструктор без параметров
        //  :base() - штука которая позволяет убрать какие-то элементы
        public Student():base()
        {
            //Person inf = new Person();
            //name = inf.Name;
            //surname = inf.Surname;
            //birthday = inf.Date;
            education_form = Education.Bachelor;
            group_number = 0;
            allTest = new List<Test>();
            passedExams = new List<Exam>();

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


        public List<Test> AllTest
        {
            get { return allTest; }
            set { allTest = value; }
        }


        public List<Exam> PassedExams
        {
            get { return passedExams; }
            set { passedExams = value; }
        }
        
        // свойство типа double
        public  double Grade //средний балл
        {
            get 
            {
                if (passedExams.Count != 0)
                {
                    double sum = 0;
                    for (int i = 0; i < passedExams.Count; i++)
                        sum += passedExams[i].Mark;
                    return sum / passedExams.Count;
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

        public void AddExams(params Exam[] newExams)
        {
            foreach (var exam in newExams)
            {  passedExams.Add(exam);  }

        }

        public void AddTest(params Test[] newTest)
        {
            foreach (var test in newTest)
            {  allTest.Add(test);   }
        }

        public override string ToString()
        {
            string str = Person.ToString() + "\nТип обучения: " + education_form + "\nНомер группы:  " + group_number + "\nСредний балл: " + Grade + " \nЭкзамены: ";
            foreach (var exam in passedExams)
            {   str += exam.ToString() + "\n";   }

            str += "Зачеты: ";
            foreach (var test in allTest)
            {  str += test.ToString() + "\n";  }

            return str;
        }

        //public virtual string ToShortString()
        //{
        //    return Person.ToString() + "\nТип обучения: " + education_form + "\nНомер группы: " + group_number +  "\nСредный балл: " + Grade + "\nКол-во экзаменов: " + passedExams.Count + "\nКол-во тестов: " + allTest.Count;
        //}


        //public virtual Student DeepCopy()
        //{
        //    Student obj = new Student(Person, education_form,group_number);
        //    foreach (var exam in passedExams)
        //    {  obj.passedExams.Add(exam); }

        //    foreach (var test in allTest)
        //    { obj.allTest.Add(test);   }

        //    return obj;
        //}


        //public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {    return false;  }

            if (!(obj is Student))
            {    return false;  }

            Student temp = obj as Student;
            if (PassedExams.Count != temp.PassedExams.Count)
            {    return false;  }

            if (AllTest.Count != temp.AllTest.Count)
            {    return false;  }

            foreach (var exam in PassedExams)
            {
                if (!temp.passedExams.Contains(exam))
                { return false; }
            }

            foreach (var test in AllTest)
            {
                if (!temp.AllTest.Contains(test))
                {   return false;  }
            }

            return Person.Equals(temp.Person) && education_form == temp.education_form &&
                   group_number == temp.group_number;

        }

        public static bool operator ==(Student obj1, Student obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Student obj1, Student obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override int GetHashCode()
        {
            return Person.GetHashCode() ^ education_form.GetHashCode() ^ group_number.GetHashCode();
        }

        public IEnumerable TestAndExam()
        {
            foreach (var item in PassedExams)
            {  yield return item;  }

            foreach (var item in AllTest)
            {  yield return item; }
        }

        public IEnumerable ExamGrade(int inputGrade)
        {
            foreach (var item in PassedExams)
            {
                if (item.Mark > inputGrade)
                { yield return item;  }
            }
        }

        public IEnumerable PassedTestsAndExams()
        {

            foreach (var exam in passedExams)
            {
                if (exam.Mark > 2)
                { yield return exam; }
            }
            foreach (var test in allTest)
            {
                if (test.result)
                { yield return test; }
            }

        }


        public IEnumerable PassedTestsWithExams()
        {
            foreach (var exam in passedExams)
            {
                foreach (var test in allTest)
                {
                    if (exam.Name == test.Name)
                    {
                        if (test.result == true && exam.Mark > 2)
                        {
                            yield return test;
                        }
                    }

                }
            }


        }
        public IEnumerator GetEnumerator()
        { return new StudentEnumerator(PassedExams, AllTest);  }

        public void SortBySubject()
        {  passedExams.Sort(); }

        public void SortByGrade()
        {   passedExams.Sort(new Exam());  }

        public void SortByDate()
        {   passedExams.Sort(new ExamComparer()); }



    }

   
}

