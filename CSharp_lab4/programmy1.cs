using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp2
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    delegate TKey KeySelector<TKey>(Student st);
    delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    delegate void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e);//?

    class programmy1
    {
        static void Main(string[] args)
        {
            // 1
            KeySelector<string> KeyGenerator = delegate (Student st)
            {
                return st.GetHashCode().ToString();
            };
            Student stud = new Student(new Person("Faina", "Ranevska", new DateTime(1999, 04, 06)), Education.Bachelor, 1);
            Exam[] a_e = { new Exam("English", 5, new DateTime(2020, 12, 12)), new Exam("Physics", 2, new DateTime(2020, 3, 20)), new Exam(), new Exam("Music", 2, new DateTime(2020, 2, 1)), new Exam("Zumba", 5, new DateTime(2020, 1, 20)) };
            stud.AddExams(a_e);
           
            Student stud2 = new Student(new Person("Alla", "Pygacheva", new DateTime(2000, 11, 20)), Education.Bachelor, 24);
            stud2.AddExams(new Exam("Math", 6, new DateTime(2020, 3, 1)), new Exam("Math", 3, new DateTime(2020, 12, 13)), new Exam("Math", 2, new DateTime(2020, 3, 1)));

            
            StudentCollection<string> stud_collection1 = new StudentCollection<string>(KeyGenerator);
            stud_collection1.collection_name = "FirstCollection";
            
            StudentCollection<string> stud_collection2 = new StudentCollection<string>(KeyGenerator);
            stud_collection2.collection_name = "SecondCollection";

            

            // 2
            Journal journal = new Journal();
            stud_collection1.StudentsChanged += journal.AddNewEntry;
            stud_collection2.StudentsChanged += journal.AddNewEntry;

            stud_collection1.AddDefaults();
            stud_collection2.AddDefaults();
            

            stud_collection1.AddStudents(stud);
            stud_collection2.AddStudents(stud2);
            

            //3
            foreach (var item in stud_collection1)
            {
                item.Value.form = Education.SecondEducation;
            }
            foreach (var item in stud_collection2)
            {
                item.Value.Group = 150;
            }
            

            stud.Group = 141;

            stud_collection1.Remove(stud);

            stud.form = Education.Specialist;

            //4
            Console.WriteLine(" Вывод ");
            Console.WriteLine(journal.ToString());
        }
    }
    }



