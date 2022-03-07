using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp2
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    delegate TKey KeySelector<TKey>(Student st);
    delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    delegate void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e);

    class programmy1
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("                                       1 задание");
            Console.WriteLine("-------------------------------------------------------------------------");
            Student stud = new Student(new Person("Фаина", " Раневская", new DateTime(1999, 04, 06)), Education.Bachelor, 1);
            Exam[] a_e = { new Exam("ИЗО", 5, new DateTime(2020, 12, 12)), new Exam("Физика", 2, new DateTime(2020, 3, 20)), new Exam(), new Exam("Музыка", 2, new DateTime(2020, 2, 1)), new Exam("Зумба", 5, new DateTime(2020, 1, 20)) };
            stud.AddExams(a_e);
            Student stud2 = new Student(new Person("Алла", " Пугачева", new DateTime(2000, 11, 20)), Education.Bachelor, 24);
            stud2.AddExams(new Exam("Математика", 6, new DateTime(2020, 3, 1)), new Exam("Русский язык", 3, new DateTime(2020, 12, 13)), new Exam("Математика", 2, new DateTime(2020, 3, 1)));
            Console.WriteLine(stud.ToString() + "\n");
            Student student2 = (Student)stud.DeepCopy();
            Console.WriteLine(student2.ToString());

            //ручной ввод
            Console.WriteLine("                                       2 задание");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Введите имя файла(Например:Testfile ): ");
            string namee = Console.ReadLine() + ".dat";
            Student student3 = new Student();

            if (student3.Load(namee))
                Console.WriteLine("Успешно\n");
            else Console.WriteLine("Файл не найден. Сейчас создастся новый файл :)\n");

            // или так
            //Console.WriteLine("                                        2 задание");
            //Console.WriteLine("-------------------------------------------------------------------------");
            //string namee = "Testfile.dat";
            //Student student3 = new Student();


            Console.WriteLine("                                       3 задание");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(student3.ToString());

            Console.WriteLine("                                       4 задание");
            Console.WriteLine("-------------------------------------------------------------------------");
            while (true)
            {
                if (student3.AddFromConsole())
                {
                    Console.WriteLine("Успешно!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Упс. Произошла ошибка. Повторите , пожалуйста, ввод \n");
                    continue;
                }
            }
            if (student3.Save(namee)) 
                Console.WriteLine("Успешно!\n");
            else Console.WriteLine("Упс. Произошла ошибка\n");

            Console.WriteLine(student3.ToString());

            Console.WriteLine("                                       5 задание");
            Console.WriteLine("-------------------------------------------------------------------------");
            if (Student.Load(namee, ref student3))
                Console.WriteLine("Успешно!\n");
            else Console.WriteLine("Файл не найден. Сейчас создастся новый файл :)\n");

            student3.AddFromConsole();

            if (Student.Save(namee, ref student3)) 
                Console.WriteLine("Успешно!\n");
            else Console.WriteLine("Упс. Произошла ошибка\n");

            Console.WriteLine("                                       6 задание");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(student3.ToString()); 

        }
    }
    }



