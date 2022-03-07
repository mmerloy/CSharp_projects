using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Exam: IDateAndCopy
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

        public static bool operator ==(Exam a, Exam b)
        { return a.Equals(b); }

        public static bool operator !=(Exam a, Exam b)
        { return !a.Equals(b); }

        public override int GetHashCode()
        { return Name.GetHashCode() ^ Mark.GetHashCode() ^ Examdate.GetHashCode(); }

        public object DeepCopy()
        { return new Exam(Name, Mark, Examdate); }

    }

}
