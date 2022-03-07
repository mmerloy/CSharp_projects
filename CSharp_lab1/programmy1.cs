using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class programmy1
    {
        static void Main(string[] args)
        {
            Student per = new Student();
            Console.WriteLine("-----------task 5--------\n" + per.ToShortString());

            Console.WriteLine("-----------task 6--------");
            Console.WriteLine(per.get_bool(Education.Bachelor));
            Console.WriteLine(per.get_bool(Education.Specialist));
            Console.WriteLine(per.get_bool(Education.SecondEducation));

            Console.WriteLine("-----------task 7--------");
            per.info = new Person("August","Augustov",new DateTime (1999,1,15));
            Console.WriteLine(per.ToString());


            Console.WriteLine("-----------task 8--------");
            //per.AddExams(new Exam(), new Exam(" English ",3,new DateTime(2000, 5, 15)));
            per.AddExams( new Exam(" English ", 3, new DateTime(2000, 5, 15)));
            Console.WriteLine(per);
            // нужно самому вводить , поэтому неверно

            //Console.WriteLine("-----------task 9 -------");
            //const int count1 = 1000000, count2 = 5, count3 = 200000;

            ////одномерный массив
            //Exam[] array1 = new Exam[count1];
            //for (int i = 0; i < count1; i++)
            //    array1[i] = new Exam("math", 4, new DateTime(2000, 5, 15));

            ////двумерный прямоугольный массив
            //Exam[,] array2 = new Exam[count2, count3];
            //for (int i = 0; i < count2; i++)
            //    for (int j = 0; j < count3; j++)
            //        array2[i, j] = new Exam("math", 4, new DateTime(2000, 5, 15));

            ////Двумерный ступенчатый массив
            //Exam[][] array3 = new Exam[5][];

            //array3[0] = new Exam[200001];
            //array3[1] = new Exam[400001];
            //array3[2] = new Exam[20001];
            //array3[3] = new Exam[180001];
            //array3[4] = new Exam[200001];

            //for (int i = 0; i < 200000; i++)
            //    array3[0][i] = new Exam("math", 4, new DateTime(2000, 5, 15));

            //for (int i = 0; i < 400000; i++)
            //    array3[1][i] = new Exam("math", 4, new DateTime(2000, 5, 15));

            //for (int i = 0; i < 20000; i++)
            //    array3[2][i] = new Exam("math", 4, new DateTime(2000, 5, 15));

            //for (int i = 0; i < 180000; i++)
            //    array3[3][i] = new Exam("math", 4, new DateTime(2000, 5, 15));

            //for (int i = 0; i < 200000; i++)
            //    array3[4][i] = new Exam("math", 4, new DateTime(2000, 5, 15));

            //Console.WriteLine("Время выполнения для одномерного массива: ");
            //var watch = Stopwatch.StartNew();

            //for (int i = 0; i < count1; i++)
            //    array1[i].Mark = 5;

            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);

            //Console.WriteLine("время выполнения для двумерного прямоугольного массива");
            //watch.Restart();

            //for (int i = 0; i < count2; i++)
            //    for (int j = 0; j < count3; j++)
            //        array2[i, j].Mark = 5;
            //watch.Stop();

            //Console.WriteLine(watch.Elapsed);

            //Console.WriteLine("Время выполнения для двумерного ступенчатого массива");
            //watch.Restart();

            //for (int i = 0; i < 200000; i++)
            //    array3[0][i].Mark = 5;

            //for (int i = 0; i < 400000; i++)
            //    array3[1][i].Mark = 5;

            //for (int i = 0; i < 20000; i++)
            //    array3[2][i].Mark = 5;

            //for (int i = 0; i < 180000; i++)
            //    array3[3][i].Mark = 5;

            //for (int i = 0; i < 200000; i++)
            //    array3[4][i].Mark = 5;
            //watch.Stop();

            //Console.WriteLine(watch.Elapsed);
            Console.WriteLine("-----task 9 -------------");
            uint[] sizes = new uint[2];
            uint temp;
            bool isChar = true;
            Console.Write("Введите кол-во строк и столбцов. Разделители - ' ', ',', ';', '.': ");
            while (isChar)
            {
                string arrSize = Console.ReadLine();
                string[] arrSizeSplited = arrSize.Split(' ', ',', ';', '.');
                for (int j = 0; j < sizes.Length; j++)
                {
                    if (!uint.TryParse(arrSizeSplited[0], out temp) || !uint.TryParse(arrSizeSplited[1], out temp) || arrSizeSplited.Length > 2 || arrSizeSplited.Length < 2)
                    {
                        Console.WriteLine("Неверный ввод");
                        Console.Write("Введите кол-во строк и столбцов. Разделители - ' ', ',', ';', '.': ");
                        break;
                    }
                    sizes[j] = temp;
                    isChar = false;
                }
            }
            Exam[] Mas1d = new Exam[sizes[0] * sizes[1]];
            Exam[,] Mas2d = new Exam[sizes[0], sizes[1]];
            Exam[][] Mas3d = new Exam[sizes[0] + sizes[1]][];
            Console.WriteLine("--------------------------");
            long re1 = 0, re2=0, re3 =0;
            for (int i = 0; i < sizes[0] * sizes[1]; i++)
            
             Mas1d[i] = new Exam();
         
            var watch = Stopwatch.StartNew();
            watch.Start();
            
            //Stopwatch.Start();
            for (int i = 0; i < sizes[0] * sizes[1]; i++)
            {
                Mas1d[i].Name = "Data";
                Mas1d[i].Mark = 2;
               
            }
            watch.Stop();
            
            re1 = watch.ElapsedMilliseconds;
            watch.Reset();
            Console.WriteLine("Одномерный массив, количество миллисекунд: " + re1);

            Console.WriteLine("==================");
            for (int i = 0; i < sizes[0]; i++)
            {
                for (int j = 0; j < sizes[1]; j++)
                {
                    Mas2d[i, j] = new Exam();
                }
            }



            //var watch1 = Stopwatch.StartNew();
            watch.Start();
            for (int i = 0; i < sizes[0]; i++)
            {
                for (int j = 0; j < sizes[1]; j++)
                {
                    Mas2d[i, j].Name = "Math";
                    Mas2d[i, j].Mark = 5;
                    
                }
            }
            watch.Stop();
            re2 = watch.ElapsedMilliseconds;
            watch.Reset();
            Console.WriteLine("Двумерный массив, количество миллисекунд: " + re2);
            
            Console.WriteLine("==================");
            for (int i = 0; i < sizes[1]; i++)
            {
                Mas3d[i] = new Exam[sizes[0]];
                for (int j = 0; j < Mas3d[i].Length; j++)
                {
                    Mas3d[i][j] = new Exam();
                }
            }

            //var watch2 = Stopwatch.StartNew();
            watch.Start();
            for (int i = 0; i < sizes[1]; i++)
            {
                for (int j = 0; j < Mas3d[i].Length; j++)
                {
                    Mas3d[i][j].Name = "Data";
                    Mas3d[i][j].Mark = 3;
                    
                }
            }
            watch.Stop();
            re3 = watch.ElapsedMilliseconds;
            watch.Reset();
            Console.WriteLine("Ступенчатый массив, количество миллисекунд: " + re3);
            watch.Reset();
            Console.WriteLine("==================");

            


            //Console.ReadKey();       

        }
    }
}


