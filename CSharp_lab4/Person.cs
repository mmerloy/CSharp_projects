using System;
using System.Collections.Generic;
using System.IO;
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
            birthday = new DateTime(2000,3,4);//?
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
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Person))
            {
                return false;
            }
            Person temp = obj as Person;
            return surname == temp.surname && name == temp.name &&
                   birthday == temp.birthday;
        }

        public static bool operator ==(Person obj1, Person obj2)
        {return obj1.Equals(obj2); }

        public static bool operator !=(Person obj1, Person obj2)
        { return !obj1.Equals(obj2); }

        public override int GetHashCode()
        {  return name.GetHashCode() ^ surname.GetHashCode() ^ birthday.GetHashCode(); }

        

        public virtual object DeepCopy()
        {
            return new Person(name, surname, birthday);
        }

     
       

    }
}
