using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Exam
    {

        public string Name
        {get; set;}

        public int Mark
        { get; set; }

        public DateTime Examdate
        { get; set; }

        //Конструктор с параметрами
        public Exam(string name_value, int mark_value, DateTime examdate_value)
        {
            Name = name_value;
            Mark = mark_value;
            Examdate = examdate_value;
        }
        //Конструктор без параметров
        public Exam()
        {
            Name = "Beril";
            Mark =  5 ;
            Examdate = new DateTime(2020, 12, 12);
        }

        // перегрузка
        public  override string ToString()
        {
            return Name + " " + " экзамен был " + Examdate.Date.ToString("d") + " оценка " + Mark+ ", ";
        }

    }

}
