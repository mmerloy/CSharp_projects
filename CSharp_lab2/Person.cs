using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Person : IDateAndCopy
    {
        //Закрытые поля
        protected string name;
        protected string surname;
        protected DateTime birthday;

        //Конструктор с параметрами
        public Person(string studentname, string studentsurname, DateTime studentbirthday)
        {
            name = studentname;
            surname = studentsurname;
            birthday = studentbirthday;
        }

        //Конструктор без параметров
        public Person()
        {
            name = "Beril";
            surname = " Berilov";
            birthday = new DateTime();
        }

        //Свойство с методами get и set;

        public string Name // Свойство типа string для доступа к полю с именем 
        {
            get { return name; }
            set { name = value; }

        }

        public string Surname // Свойство типа string для доступа к полю с фамилией
        {
            get { return surname; }
            set { surname = value; }
        }
        
        public DateTime Date
        {
            get { return birthday; }
            set { birthday = new DateTime(value.Year, value.Month, value.Day); }
        }

       
        public int ChangeYear
        {
            get { return birthday.Year;}
            set { birthday = new DateTime(value, birthday.Month, birthday.Day);}
        }

        public override string ToString()
        {  return name + " " + surname + " " + birthday.ToString("d");}

        public virtual string ToShortString()
        { return name + " " + surname; }

        public override bool Equals(object obj)
        {
            if ((obj.GetType() != GetType()) || (obj == null)) return false;
            Person comp = (Person)obj;
            return (name == comp.name) && (surname == comp.surname) && (birthday == comp.birthday);
        }

        public static bool operator ==(Person a, Person b)
        { return a.Equals(b); }

        public static bool operator !=(Person a, Person b)
        { return !a.Equals(b); }

        //виртуальный метод int GetHashCode();
        public override int GetHashCode()
        {  return name.GetHashCode() ^ surname.GetHashCode() ^ birthday.GetHashCode(); }

        //виртуальный метод object DeepCopy()
        public virtual object DeepCopy()
        { return new Person(name, surname, birthday); }

    }
}
