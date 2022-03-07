using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Exam: IComparable, IComparer<Exam>
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
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Exam))
            {
                return false;
            }
            Exam temp = obj as Exam;
            return temp.Mark == Mark && temp.Name == Name && temp.Examdate == Examdate;
        }



       
        public static bool operator ==(Exam obj1, Exam obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Exam obj1, Exam obj2)
        {
            return !(obj1.Equals(obj2));
        }


        public override int GetHashCode()
        { return Name.GetHashCode() ^ Mark.GetHashCode() ^ Examdate.GetHashCode(); }

        public int CompareTo(object obj)
        {
            if (!(obj is Exam))
            {
                throw new ArgumentException();
            }

            return Name.CompareTo(((Exam)obj).Name);
        }

        public int Compare(Exam x, Exam y)
        {
            return x.Mark.CompareTo(y.Mark);
        }


        //public object DeepCopy()
        //{ return new Exam(Name, Mark, Examdate); }

    }

}
