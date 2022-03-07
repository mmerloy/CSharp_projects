using System;
using System.Collections.Generic;


namespace ConsoleApp2
{
    class Exam: IDateAndCopy, IComparable<Exam>, IComparer<Exam>
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
            Name = "Zumba";
            Mark =  5 ;
            Examdate = new DateTime(2020, 12, 12);
        }

        // перегрузка
        public  override string ToString()
        { return Name + " " + " экзамен был " + Examdate.Date.ToString("d") + " оценка " + Mark.ToString()+ "\n "; }

        public DateTime Date
        {
            get { return Examdate; }
            set { Examdate=new DateTime (value.Year, value.Month, value.Day); }
        }

        public override bool Equals(object obj)
        {
            if ((obj.GetType() != GetType()) || (obj == null)) return false;
            Exam comp = (Exam)obj;
            return (Name == comp.Name) && (Mark == comp.Mark) && (Examdate == comp.Examdate);
        }




        public static bool operator ==(Exam obj1, Exam obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Exam obj1, Exam obj2)
        {
            return !obj1.Equals(obj2);
        }


        public override int GetHashCode()
        { return Name.GetHashCode() ^ Mark.GetHashCode() ^ Examdate.GetHashCode(); }

        public int CompareTo(Exam x)
        {
            return Name.CompareTo(x.Name);
        }

        public int Compare(Exam x, Exam y)
        {
            return x.Mark.CompareTo(y.Mark);
        }


        public object DeepCopy()
        { return new Exam(Name, Mark, Examdate); }

    }

}
