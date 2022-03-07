using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class Test
    {
        //открытые автореализуемые свойства, доступные для чтения и записи:
        public string Name { get; set; }
        public bool result { get; set; }

        //конструктор c параметрами типа string и bool для инициализации свойств класса 
        public Test(string _Name, bool _result)
        {
            Name = _Name;
            result = _result;
        }

        //конструктор без параметров, инициализирующий все свойства класса
        //некоторыми значениями по умолчанию
        public Test()
        {
            Name = "A";
            result = false;
        }


        //перегруженная(override) версия виртуального метода string ToString() для
        //формирования строки со значениями всех свойств класса.
        public override string ToString()
        { return "\n Предмет: "+ Name + "   Зачет? " + result.ToString(); }

       

        public override bool Equals(object obj)
        {
            if (obj == null)
            {   return false;  }

            if (!(obj is Test))
            { return false;  }

            Test temp = obj as Test;
            return result == temp.result && Name == temp.Name;
        }


        public static bool operator ==(Test obj1, Test obj2)
        {   return obj1.Equals(obj2);  }

        public static bool operator !=(Test obj1, Test obj2)
        { return !obj1.Equals(obj2); }

        public override int GetHashCode()
        {    return result.GetHashCode() ^ Name.GetHashCode();   }


    }
}
   
