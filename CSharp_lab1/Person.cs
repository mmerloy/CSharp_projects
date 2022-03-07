using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Person
    {
        //Закрытые поля
        private string name;
        private string surname;
        private DateTime birthday;

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
            birthday = new DateTime(2000, 1, 1);
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

        DateTime Birthday// Свойство типа DateTime для доступа к полю с датой рождения
        {
            get { return birthday; }
            set { birthday = new DateTime(birthday.Year, birthday.Month, birthday.Day); }
        }

        // свойство типа int c методами get и set для получения информации(get) и 
        //изменения(set) года рождения в закрытом поле типа DateTime, в котором хранится дата рождения.
        public int ChangeYear// меняет год рождения
        {
            get
            { return birthday.Year;}
            set
            { birthday = new DateTime(value, birthday.Month, birthday.Day);}
        }

        public override string ToString()
        {  return name + " " + surname + " " + birthday.ToString("d");}

        public string ToShortString()
        { return name + " " + surname; }

    }
}
