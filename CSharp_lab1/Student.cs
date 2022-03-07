using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Linq;
using ConsoleApp2;


namespace ConsoleApp2
{ 
    class Student
    {
        //закрытые поля
        private Person student_inf;
        private Education education_form;
        private int group_number;
        private Exam[] passed_exams;
        
        // определяем конструктор с параметрами
        public Student (Person student_inf1, Education education_form1, int group_number1, Exam[]passed_exams1)
        {
            student_inf = student_inf1;
            education_form = education_form1;
            group_number = group_number1;
            passed_exams = passed_exams1;
        } 
        //определяем конструктор без параметров
        public Student()
        {
            student_inf = new Person();
            education_form = Education.Specialist;
            group_number = 24;
            passed_exams = new Exam[0];

        }
        //определяем  свойства c методами get и set:
        public Person info
        {
            get
            { return student_inf; }
            set
            { student_inf = value;}
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
            { group_number = value; }
        }
        public Exam[] Exams
        {
            get
            { return passed_exams;}
            set
            { passed_exams = value;}
        }

        // свойство типа double
       
        public  double Grade //средний балл
        {
            get 
            {

                //double sum = 0;
                //foreach (Exam www in passed_exams)
                //sum += www.Mark;
                //return (sum / passed_exams.Length);

                if (passed_exams.Length != 0)
                {
                    double sum = 0;
                    for (int i = 0; i < passed_exams.Length; i++)
                        sum += passed_exams[i].Mark;
                    return (sum / passed_exams.Length);
                }
                else
                    return 0;

            }

        }


        //индексатор булевского типа (только с методом get) 
        public bool get_bool(Education b)
        {
            if (education_form == b) return true;
            else return false;
        }

        //метод
        public void AddExams(params Exam[] mass)
        {
            /*
            Exam[] tmp = new Exam[mass.Length + passed_exams.Length];   // тоже верно
            for (int i = 0; i <passed_exams.Length; i++)
                tmp[i] = passed_exams[i];
            for (int i = 0; i < mass.Length; i++)
                tmp[i + passed_exams.Length] = mass[i];
            passed_exams = tmp;
            */
            // но лучше так 
            int oldSize = passed_exams.Length;
            int newSize = passed_exams.Length + mass.Length;



            Array.Resize<Exam>(ref passed_exams, newSize);
            Array.Copy(mass, 0, passed_exams, oldSize, mass.Length);


        }

        //перегрузка
        public override string ToString()
        {
            string str = student_inf.ToString() + " " + group_number;
            for (int i = 0; i < passed_exams.Length; i++)
                str += " " + passed_exams[i].ToString();
            return str;
        }

        //виртуальный метод
        public virtual string ToShortString()
        {
            return $"{student_inf} {group_number} {Grade}\n";
        }
       

    }

   
}

