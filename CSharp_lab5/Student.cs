using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConsoleApp2
{
    [Serializable]
    class Student: Person, IDateAndCopy, IEnumerable, INotifyPropertyChanged
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
       
        event System.ComponentModel.PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            { throw new NotImplementedException();}

            remove
            { throw new NotImplementedException(); }
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
            { education_form = value; OnPropertyChanged("( Меняем тип обучения )"); }
        }


        public int Group
        {
            get
            {return group_number;}
            set
            {
                if (value <= 100 || value > 599)
                { throw new ArgumentException("Number of group must be > 100 and < 600");  }
                OnPropertyChanged("(Меняем номер группы)\t");
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

            str += " Зачеты: ";
            foreach (var test in allTest)
            {  str += test.ToString() + "\n";  }

            return str;
        }

        public override string ToShortString()
        {
            return Person.ToString() + "\nТип обучения: " + education_form + "\nНомер группы: " + group_number + "\nСредный балл: " + Grade + "\nКол-во экзаменов: " + passedExams.Count + "\nКол-во тестов: " + allTest.Count;
        }

       

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
        {   passedExams.Sort(new Exam()); }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        //экземплярные методы
        public override object DeepCopy()
        {
            MemoryStream mem= new MemoryStream();
            BinaryFormatter eee = new BinaryFormatter();
            eee.Serialize(mem, this);
            mem.Position = 0;
            Student returnValue = (Student)eee.Deserialize(mem);
            mem.Close();
            mem.Dispose();
            return returnValue;
        }

        public bool Save(string filename)
        {
            try
            {
                BinaryFormatter eee = new BinaryFormatter();
                using (FileStream fl = new FileStream(filename, FileMode.Append))
                {
                    eee.Serialize(fl, this);
                    Console.WriteLine("(Объект был сериализован)");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Load(string filename)
        {
            try
            {
                BinaryFormatter eee = new BinaryFormatter();
                using FileStream fl = new FileStream(filename, FileMode.OpenOrCreate);
                Student student = (Student)eee.Deserialize(fl);
                Console.WriteLine("( Объект был десериализован)");
               
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Введите название экзамена , затем оценку и дату экзамена( все должно быть введено через пробел) ");
                string line = Console.ReadLine();
                string[] lines = line.Split(' ');
                passedExams.Add(new Exam(lines[0], Convert.ToInt32(lines[1]), new DateTime(Convert.ToInt32(lines[2]), Convert.ToInt32(lines[3]), Convert.ToInt32(lines[4]))));
                return true;
            }
            catch
            {
                return false;
            }
        }
        //статические методы

        public static bool Save(string filename, ref Student obj)
        {
            try
            {
                BinaryFormatter eee= new BinaryFormatter();
                using (FileStream fileStream = new FileStream(filename, FileMode.Append))
                {
                    eee.Serialize(fileStream, obj);
                    Console.WriteLine("(Объект был сераилизован)");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Load(string filename, ref Student obj)
        {
            try
            {
                BinaryFormatter eee = new BinaryFormatter();
                using FileStream fl= new FileStream(filename, FileMode.OpenOrCreate);
                obj = (Student)eee.Deserialize(fl);
                Console.WriteLine("(Объект был десериализован)");
                return true;
            }
            catch
            {
                Console.WriteLine("Ошибка :(");
                return false;
            }
        }
    }

   
}

